using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using Common;
using Common.Logger;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.UI;

namespace ShopOrderCustom.Models
{
    public class GoodsReturnModel : ModelLayout
    {
        private readonly DateTime _serverDate;
        private readonly Guid _shopId;
        
        private bool _autoFill;
      
        private DateTime _filterDate;
        private XtraForm _view;
        private readonly GoodsReturnAddModel _goodsReturnAddModel;

        public List<ReturnPosStateObj> ReturnStatePos { get; private set; }

        public bool AllowEdit { get { return IsAllowEdit(); } }

        private ReturnObj _currentReturnHeader;
        public ReturnObj CurrentReturnHeader
        {
            get { return _currentReturnHeader; }
            set { _currentReturnHeader = value; }
        }

        [InjectionConstructor]
        public GoodsReturnModel(IUnityContainer unityContainer)
            : base(unityContainer)
        {
            ViewCode = ViewConst.ED_GOODRETURN;
            this.unityContainer = unityContainer;
            _shopId = Guid.Parse(unityContainer.Resolve<IOrderUserInfo>().Property["USER_SHOP"]);
            _serverDate = DateTime.Parse(unityContainer.Resolve<IOrderUserInfo>().Property["SERVER_DATE"]);
            _goodsReturnAddModel = unityContainer.Resolve<GoodsReturnAddModel>();
            LoadStatePos();
        }

        public bool IsAllowAdd()
        {
            return _serverDate.Date == _filterDate.Date;
        }
        private bool IsAllowEdit()
        {
            if (_currentReturnHeader != null)
                return ((_currentReturnHeader.ReturnStateId == 1) && (_serverDate.Date == _currentReturnHeader.CreateDate.Date));
            return true;
        }

        public IUnityContainer unityContainer { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new GoodsReturnForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        public DateTime FilterDate
        {
            get { return _filterDate; }
            set
            {
                if ((_filterDate != value))
                {
                    _filterDate = value;
                    SendChangeDataFilter(_filterDate);
                }
            }
        }

        public event ChangeDateFilter ChangeDateFilter;

        protected virtual void SendChangeDataFilter(DateTime date)
        {
            if ((ChangeDateFilter != null))
            {
                ChangeDateFilter(this, new EventChangeDateFilter {Date = date});
            }
        }

        public Returns GetReturnsHeader()
        {
            var ret = unityContainer.Resolve<Returns>();
            ret.Load(_filterDate);
            return ret;          
        }

        private void LoadStatePos()
        {
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                ReturnStatePos = (from or in oc.DataBaseContext.sp_sel_ReturnStatesPos()
                                  select new ReturnPosStateObj() { Id = or.id, Name = or.Name, StateCode = or.StateCode }).ToList();
            }
        }

        public void CommitReturn()
        {
            if (_currentReturnHeader != null) 
            {
                if (_currentReturnHeader.ReturnItems.Count == 0)
                    XtraMessageBox.Show("Нельзя подтвердить пустой возврат", "Подтверждение возврата", MessageBoxButtons.OK);
                else
                {
                    int oldState = _currentReturnHeader.ReturnStateId;
                    try
                    {

                        _currentReturnHeader.CommitReturn();
                        using (var oc = unityContainer.Resolve<OrderDataContext>())
                        {
                            WindowsIdentity wi = WindowsIdentity.GetCurrent();
                            oc.DataBaseContext.sp_upd_ReturnHeaderState(_currentReturnHeader.Id,
                                                                        _currentReturnHeader.ReturnStateId,
                                                                        wi.Name);
                        }
                    }
                    catch (Exception)
                    {
                        _currentReturnHeader.ReturnStateId = oldState;
                        throw;
                    }
                }
            }
        }

        public ReturnItems GetReturnList()
        {
            _currentReturnHeader.LoadItems();
            return _currentReturnHeader.ReturnItems;
        }

        delegate void Refresh();

        public void AddReturnItem()
        {
            if (CurrentReturnHeader != null)
            {
                _goodsReturnAddModel.IsEdit = false;
                //_goodsReturnAddModel.IsChanged = false;
                using (var dlg = new GoodsReturnAddDlg(_goodsReturnAddModel))
                {
                    var rf = new Refresh(_goodsReturnAddModel.RefreshInvoiceData);
                    rf();

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            CurrentReturnHeader.AddNewItem(_goodsReturnAddModel.GetReturnItemObj());
                            _goodsReturnAddModel.GetInvoiceData().Refresh(_goodsReturnAddModel.GetReturnItemObj().InvoiceDataId);
                            _goodsReturnAddModel.IsChanged = true;

                        }
                        catch (Exception e)
                        {
                            XtraMessageBox.Show(e.Message, "Создание позиции возврата");
                        }
                        
                    }
                }  
            }
        }

        public void DelReturnItem(ReturnItemObj items)
        {
            if (CurrentReturnHeader != null)
            {
                if(XtraMessageBox.Show("Вы действительно хотите удалить позицию?", "Удаление позиции возврата", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (var oc = unityContainer.Resolve<OrderDataContext>())
                    {
                        //WindowsIdentity wi = WindowsIdentity.GetCurrent();
                        oc.DataBaseContext.sp_del_ReturnItem(items.Id);
                    }
                    CurrentReturnHeader.ReturnItems.Remove(items);
                    _goodsReturnAddModel.RemoveReturnItem(items);
                }
            }
        }

        public void EditReturnItem(ReturnItemObj item)
        {
            if ((CurrentReturnHeader != null) && (item != null))
            {
                _goodsReturnAddModel.EditReturnItemObj(item);
                using (var dlg = new GoodsReturnAddDlg(_goodsReturnAddModel))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        CurrentReturnHeader.EditItem(item.Id, _goodsReturnAddModel.GetReturnItemObj());
                        _goodsReturnAddModel.GetInvoiceData().Refresh(_goodsReturnAddModel.GetReturnItemObj().InvoiceDataId);
                        _goodsReturnAddModel.EdititItem = null;
                    }
                }  
            }
        }

    }
}