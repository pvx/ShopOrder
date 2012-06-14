using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using Common;
using Common.Logger;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom.TreeData;
using ShopOrderCustom.UI;
using ShopOrderExcel;
using ShopOrderExcel.Interfaces;

namespace ShopOrderCustom.Models
{
    public delegate void ChangeDateFilter(object sender, EventChangeDateFilter e);

    public delegate void ChangeManagerType(object sender, EventChangeManagerType e);

    public class EventChangeManagerType : EventArgs
    {
        public OrderManagerType ManagerType { get; set; }
    }


    /// <summary>
    /// Модель данных UI менеджера заказов
    /// </summary>
    public class OrderManagerModel : ModelLayout
    {

        private BackgroundWorker _backgroundWorker;

        private OrderManagerType _managerType;
        public OrderManagerType ManagerType
        {
            get { return _managerType; }
            set
            {
                _managerType = value;
                OnManagerTypeChanged(_managerType);
            }
        }

        public event ChangeDateFilter ChangeDateFilter;
        public event ChangeManagerType ManagerTypeChanged;

        [Dependency]
        public IOrderUserInfo OrderUserInfo { get; set; }

        [Dependency]
        public Logger Log { get; set; }

        public Guid IdOrderHeader { get; set; }

        private DateTime _filterDate;

        public DateTime ServerDate
        {
            get { return _serverDate; }
        }

        public DateTime FilterDate
        {
            get
            {
                return _filterDate;
            }
            set
            {
                if ((_filterDate != value))
                {
                    _filterDate = value;
                    SendChangeDataFilter(_filterDate);
                }
            }
        }
        private XtraForm _view;

        private OrderHeaderData _currentOrderHeader;
        private readonly DateTime _serverDate;

        protected virtual void OnManagerTypeChanged(OrderManagerType managerType)
        {
            if(ManagerTypeChanged != null)
            {
                ManagerTypeChanged(this, new EventChangeManagerType() { ManagerType = managerType });
            }
        }

        protected virtual void SendChangeDataFilter(DateTime date)
        {
            if ((ChangeDateFilter != null))
            {
                ChangeDateFilter(this, new EventChangeDateFilter { Date = date});
            }
        }

        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new OrderManagerForm(this);

                return _view;
            }
            set
            {
                if (_view == null)
                    _view = value;}
        }

        public OrderHeaderData CurrentOrderHeader
        {
            get { return _currentOrderHeader; }
            set { _currentOrderHeader = value; }
        }
 
        public object GetTreeDs()
        {
            switch (ManagerType)
            {
                case OrderManagerType.OrderManager:
                    return GetOrdersHeader();
                case OrderManagerType.PreOrderManager:
                    return GetPreOrdersHeader();
                default:
                    return null;
            }
        }

        private ShopNode GetOrdersHeader()
        {
            var os = UnityContainer.Resolve<ShopNode>();
            os.FilterDate = _filterDate;
            os.Load();
            return os;           
        }

        private PreShopNode GetPreOrdersHeader()
        {
            var os = UnityContainer.Resolve<PreShopNode>();
            os.FilterDate = _filterDate;
            os.Load();
            return os;
        }
        
        public bool CanCheck(OrderHeaderObj orderHeaderObj)
        {
            bool ret = false;
            if (orderHeaderObj.IdOrderState == 2)
                ret = OrderUserInfo.UserName.Equals(orderHeaderObj.LockUser) || string.IsNullOrEmpty(orderHeaderObj.LockUser);
            return ret;
        }

        public object GetGridDs()
        {
            switch (ManagerType)
            {
                case OrderManagerType.OrderManager:
                    return GetOrderList();
                case OrderManagerType.PreOrderManager:
                    return GetPreOrderList();
                default:
                    return null;
            }
        }

        private BindingList<GoodsBalanceObj> GetOrderList()
        {
            if (_currentOrderHeader != null)
            {
                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    var orders = oc.DataBaseContext.sp_sel_OrderGoodsByHeader(_currentOrderHeader.IdOrderHeader).ToList();


                    var balance = new BindingList<GoodsBalanceObj>
                                      {
                                          AllowEdit = _currentOrderHeader.IdOrderState == 1
                                      };

                    foreach (var vo in orders)
                    {
                        var bl = new GoodsBalanceObj
                        {
                            Barcode = vo.Barcode,
                            Code = vo.Code,
                            Date = vo.Date,FreeBalance = vo.FreeBalance.GetValueOrDefault(),
                            Group = vo.GoodsGroup,
                            id = vo.id_GoodsBalance,
                            Measure = vo.Measure,
                            MinOrder = vo.MinOrder.GetValueOrDefault(),
                            Name = vo.Name,
                            Price = vo.Price.GetValueOrDefault(),
                            ReqQuantity = vo.ReqQuantity,
                            Ordered = vo.Ordered,
                            Quantity = vo.Balance,
                            QuantityInPack = vo.QuantityInPack.GetValueOrDefault(),
                            Reserved = vo.Reserved.GetValueOrDefault(),
                            Supplier = vo.Supplier,
                            SelfImport = vo.SelfImport.GetValueOrDefault(false)
                        };
                        balance.Add(bl);
                    }
                    return balance;
                }
            }
            return null;
        }

        private BindingList<PreGoodsBalanceData> GetPreOrderList()
        {
            if (_currentOrderHeader != null)
            {
                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    var orders = oc.DataBaseContext.sp_sel_PreOrderGoodsByHeader(_currentOrderHeader.IdOrderHeader).ToList();


                    var balance = new BindingList<PreGoodsBalanceData>
                    {
                        AllowEdit = _currentOrderHeader.IdOrderState == 1
                    };

                    foreach (var vo in orders)
                    {
                        var bl = new PreGoodsBalanceData
                        {
                            Barcode = vo.Barcode,
                            Code = vo.Code,
                            Date = vo.Date,
                            FreeBalance = vo.FreeBalance.GetValueOrDefault(),
                            Group = vo.GoodsGroup,
                            id = vo.id_GoodsBalance,
                            Measure = vo.Measure,
                            MinOrder = vo.MinOrder.GetValueOrDefault(),
                            Name = vo.Name,
                            Price = vo.Price.GetValueOrDefault(),
                            ReqQuantity = vo.ReqQuantity,
                            Ordered = vo.Ordered,
                            Quantity = vo.Balance,
                            QuantityInPack = vo.QuantityInPack.GetValueOrDefault(),
                            Reserved = vo.Reserved.GetValueOrDefault(),
                            Supplier = vo.Supplier,
                            SelfImport = vo.SelfImport.GetValueOrDefault(false)
                        };
                        bl.AddCommitData(bl.SelfImport ? null : new GoodsBalanceObj(){Code = bl.Code});
                        balance.Add(bl);
                    }
                    return balance;
                }
            }
            return null;
        }

        public void TransferOrder()
        {
            if ((CurrentOrderHeader != null) && (CurrentOrderHeader.IdOrderState == 2))
            {
                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    WindowsIdentity wi = WindowsIdentity.GetCurrent();
                    oc.DataBaseContext.sp_ins_TransferOrder(CurrentOrderHeader.IdOrderHeader, wi.Name);
                    CurrentOrderHeader.IdOrderState = 5;
                }
            }
        }

        void CreateOrdersFromXLS(IEnumerable<IDataRecord> dataRecords, BackgroundWorker bw)
        {
            try
            {
                int recTotal = dataRecords.Count();
                int recCurent = 0;

                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    foreach (OrderDataRecord dr in dataRecords)
                    {
                        foreach (var itm in dr.ShopsOrder)
                        {
                            oc.DataBaseContext.sp_ins_OrderFromXLS(itm.Key, itm.Value, dr.Code, WindowsIdentity.GetCurrent().Name);
                        }
                        
                        recCurent++;
                        bw.ReportProgress((int)((float)recCurent / (float)recTotal * 100));
                    }
                    oc.DataBaseContext.sp_get_orders_fromXLS();
                }
            }
            catch (Exception e)
            {
                Log.Error("CreateOrdersFromXLS", e);
                throw;
            }
        }

        void CreateNestleOrders(IEnumerable<IDataRecord> dataRecords, BackgroundWorker bw)
        {
            try
            {
                int recTotal = dataRecords.Count();
                int recCurent = 0;

                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    foreach (var dataRecord in dataRecords)
                    {
                        var nr = ((NestleOrderRecord)dataRecord);
                        DateTime date = DateTime.ParseExact(nr.DocDate, "MM-dd-yyyy", CultureInfo.InvariantCulture);

                        oc.DataBaseContext.sp_ins_NestleOrder(nr.DocNumber, date, nr.ShopPoint,
                                                              double.Parse(nr.Quantity), nr.Code, WindowsIdentity.GetCurrent().Name);
                        recCurent++;
                        
                        bw.ReportProgress((int)((float)recCurent / (float)recTotal * 100));
                    }
                    oc.DataBaseContext.sp_get_orders_nestle();
                }
            }
            catch (Exception e)
            {
                Log.Error("CreateNestleOrders", e);
            }
        }

        void CreateDistribOrders()
        {
            try
            {
                using (var oc = UnityContainer.Resolve<OrderDataContext>())
                {
                    oc.DataBaseContext.sp_get_orders_fromDistribution(WindowsIdentity.GetCurrent().Name);
                }
            }
            catch (Exception e)
            {
                Log.Error("CreateDistribOrders", e);
            }
        }

        public void LoadFromExcelOrders(string path, ProgressChangedEventHandler progressChangedEventHandler, RunWorkerCompletedEventHandler completedEventHandler)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var ex = UnityContainer.Resolve<ExcelOrderImport>();
                var dataExcel = ex.GetDataFromExcel(path);
                if ((dataExcel != null) && (dataExcel.Count > 0))
                {
                    _backgroundWorker = new BackgroundWorker();
                    _backgroundWorker.DoWork += BackgroundOrderImport;
                    _backgroundWorker.RunWorkerCompleted += completedEventHandler;
                    _backgroundWorker.WorkerReportsProgress = true;
                    _backgroundWorker.WorkerSupportsCancellation = false;
                    _backgroundWorker.RunWorkerAsync(dataExcel);

                    _backgroundWorker.ProgressChanged += progressChangedEventHandler;
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void LoadFromExcelNestleOrders(string path, ProgressChangedEventHandler progressChangedEventHandler, RunWorkerCompletedEventHandler completedEventHandler)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var ex = UnityContainer.Resolve<NestleOrderImport>();
                var dataExcel = ex.GetDataFromExcel(path);
                if ((dataExcel != null) && (dataExcel.Count > 0))
                {
                    _backgroundWorker = new BackgroundWorker();
                    _backgroundWorker.DoWork += BackgroundNestleImport;
                    _backgroundWorker.RunWorkerCompleted += completedEventHandler;
                    _backgroundWorker.WorkerReportsProgress = true;
                    _backgroundWorker.WorkerSupportsCancellation = false;
                    _backgroundWorker.RunWorkerAsync(dataExcel);
                    
                    _backgroundWorker.ProgressChanged += progressChangedEventHandler;
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default; 
            }
        }

        public void CreateOrdersFromDistribution(ProgressChangedEventHandler progressChangedEventHandler, RunWorkerCompletedEventHandler completedEventHandler)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                    _backgroundWorker = new BackgroundWorker();
                    _backgroundWorker.DoWork += BackgroundCreateDistribOrders;
                    _backgroundWorker.RunWorkerCompleted += completedEventHandler;
                    _backgroundWorker.WorkerReportsProgress = true;
                    _backgroundWorker.WorkerSupportsCancellation = false;
                    _backgroundWorker.RunWorkerAsync();

                    _backgroundWorker.ProgressChanged += progressChangedEventHandler;
                
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void BackgroundCreateDistribOrders(object sender, DoWorkEventArgs e)
        {
            CreateDistribOrders();
        }

        void BackgroundOrderImport(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            CreateOrdersFromXLS((IList<IDataRecord>)e.Argument, worker);
        }

        void BackgroundNestleImport(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            CreateNestleOrders((IList<IDataRecord>)e.Argument, worker);
        }

        [InjectionConstructor]
        public OrderManagerModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            ViewCode = ViewConst.PROCESS_ORDERS;
            _serverDate = DateTime.Parse(unityContainer.Resolve<IOrderUserInfo>().Property["SERVER_DATE"]);
            ManagerType = OrderManagerType.OrderManager; 
        }
    }
}