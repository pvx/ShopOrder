using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Common;
using Common.Events;
using DataBase.DataSet.DataSetTableAdapters;
using Microsoft.Practices.Unity;

namespace DataBase.DataSet
{
    [Obsolete]
    public class DataClass : IDisposable
    {
        public readonly sp_sel_CurrentOrderBalanceTableAdapter CurrentOrderBalance;
        public readonly sp_sel_OrdersHeaderTableAdapter OrdersHeader;
        private DataSet _dataset;
        private Guid _idOrderHeader;
        private int _idOrderHeaderState;

        public int IdStorehouse { get; set; }

        public int IdOrderHeaderState
        {
            get { return _idOrderHeaderState; }
            set 
            {
                _idOrderHeaderState = value;
                _dataset.sp_sel_CurrentOrderBalance.ReqQuantityColumn.ReadOnly = (_idOrderHeaderState != 1);
            }
        }

        [InjectionConstructor]
        public DataClass(IOrderConnection orderConnection)
        {
            SqlConnection connection = orderConnection.GetSqlConnection();

            _dataset = new DataSet();
            CurrentOrderBalance = new sp_sel_CurrentOrderBalanceTableAdapter();
            CurrentOrderBalance.Connection = connection;
            CurrentOrderBalance.ClearBeforeFill = true;

            OrdersHeader = new sp_sel_OrdersHeaderTableAdapter();
            OrdersHeader.Connection = connection;
            OrdersHeader.ClearBeforeFill = true;

            OnChangeOrderHeader += DataClass_OnChangeOrderHeader;
            OnDataRowChange += DataClass_OnDataRowChange;
        }

        public DataSet DataSet
        {
            get { return _dataset; }
            set { _dataset = value; }
        }

        public Guid IdOrderHeader
        {
            get { return _idOrderHeader; }
        }

        [Dependency]
        public IOrderUserInfo UserInfo { get; set; }

        #region IDisposable Members

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        #endregion

        public event OnChangeOrderHeader OnChangeOrderHeader;
        public event OnDataRowChange OnDataRowChange;

        public void InvokeOnChangeOrderHeader(EventChangeOrderHeader eventargs)
        {
            OnChangeOrderHeader handler = OnChangeOrderHeader;
            if (handler != null) handler(this, eventargs);
        }

        private void DataClass_OnDataRowChange(object sender, EventArgs eventArgs)
        {
            CurrentOrderBalanceFill(_idOrderHeader, false);
        }

        private void DataClass_OnChangeOrderHeader(object sender, EventChangeOrderHeader eventArgs)
        {
            _idOrderHeader = eventArgs.IdOrderHeader;
            IdOrderHeaderState = eventArgs.OrderHeaderState;
            CurrentOrderBalanceFill(eventArgs.IdOrderHeader, true);
        }

        public void CurrentOrderBalanceFill(Guid idOrderHeader, bool clearBeforeFill = false)
        {
            _dataset.sp_sel_CurrentOrderBalance.RowChanged -= SpSelCurrentOrderBalanceRowChanged;
            CurrentOrderBalance.ClearBeforeFill = clearBeforeFill;
            CurrentOrderBalance.Fill(_dataset.sp_sel_CurrentOrderBalance, idOrderHeader);
            _dataset.sp_sel_CurrentOrderBalance.RowChanged += SpSelCurrentOrderBalanceRowChanged;
        }

        private void SpSelCurrentOrderBalanceRowChanged(object sender, DataRowChangeEventArgs e)
        {
            SetOrder(e.Row);
        }

        private void SetOrder(DataRow row)
        {
            double minorder = 0;
            var id = (Guid) row["id_GoodsBalance"];
            Guid idOrder = _idOrderHeader;

            {
                double quant = 0;
                var balance = (double) row["Balance"];
                var ordered = (double) row["Ordered"];

                if (row["MinOrder"].ToString() != "")
                {
                    minorder = (double) row["MinOrder"];
                }

                if (row["ReqQuantity"].ToString() != "")
                {
                    quant = (double) row["ReqQuantity"];
                }

                quant = GetMinOrderQuantity(quant, minorder);

                if ((ordered + balance) < quant)
                {
                    if (
                        MessageBox.Show("Остатки меньше чем заказываемое количество. Заказать?", "Внимание!",
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                        SpCreateOrder(id, idOrder, quant, IdStorehouse);
                    else
                        row["ReqQuantity"] = 0;
                }
                else
                    SpCreateOrder(id, idOrder, quant, IdStorehouse);
            }
        }

        private static double GetMinOrderQuantity(double reqQuantity, double minOrderQuantity)
        {
            double result = reqQuantity;
            double mod = reqQuantity%minOrderQuantity;

            if ((reqQuantity != 0) && (minOrderQuantity != 0) && (!double.IsNaN(mod)))
            {
                if (reqQuantity < minOrderQuantity)
                    result = minOrderQuantity;
                else if (reqQuantity > minOrderQuantity)
                {
                    result = mod == 0
                                 ? reqQuantity
                                 : reqQuantity - mod + ((mod/minOrderQuantity) >= 0.4 ? minOrderQuantity : 0);
                }

                result = ((reqQuantity/result) >= 0.4) ? result : reqQuantity - mod;
            }

            return result;
        }

        public void OrdersHeaderFill(bool clearBeforeFill = false)
        {
            OnChangeOrderHeader -= DataClass_OnChangeOrderHeader;
            OrdersHeader.ClearBeforeFill = clearBeforeFill;
            OrdersHeader.Fill(_dataset.sp_sel_OrdersHeader);
            OnChangeOrderHeader += DataClass_OnChangeOrderHeader;
        }

        public void SpCreateOrder(Guid idGoodBalance, Guid idOrderHeader, double quantity, int idStorehouse)
        {
            CurrentOrderBalance.sp_ins_Order(idGoodBalance, idOrderHeader, quantity, idStorehouse);
            if (OnDataRowChange != null)
                OnDataRowChange(this, new EventArgs());
        }

        public void SpUpdOrdersHeaderState(int state)
        {
            OrdersHeader.sp_upd_OrdersHeaderState(_idOrderHeader, state);
            IdOrderHeaderState = state;
            OrdersHeaderFill();
        }

        public void SpInsOrdersHeader(Guid idOrderHeader)
        {         
            string idUser = UserInfo.Property["USER_ID"];
            if(string.IsNullOrEmpty(idUser))
                throw new ArgumentNullException("SpInsOrdersHeader: USER_ID is null");
                OrdersHeader.sp_ins_OrdersHeader(idOrderHeader, new Guid(idUser));
                OrdersHeaderFill();
            
        }

        public void SpClearOrder(bool isAlco)
        {
            OrdersHeader.sp_upd_ClearOrder(_idOrderHeader, isAlco);
            if (OnDataRowChange != null)
                OnDataRowChange(this, new EventArgs());
        }
    }
}