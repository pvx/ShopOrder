using System;

namespace DataBase.DataObject
{
    /// <summary>
    /// Событие изменения количества товара при заказе
    /// </summary>
    public class EventChangeReqQuantity : EventArgs
    {
        public GoodsBalanceObj GoodsObj { get; set; }
    }

    public class EventChangeBalance : EventArgs
    {
            public EditGoodsBalanceObj GoodsObj { get; set; }
    }
    
    public class EventChangeMinOrder : EventArgs
    {
        public MinOrderObj MinOrdObj { get; set; }
    }

    public class EventChangeReqAssortObj : EventArgs
    {
        public ReqAssortObj ReqAssortObj { get; set; }
    }

    public class EventChangeDateFilter : EventArgs
    {
        public DateTime Date { get; set; }
        public DateTime DateEnd { get; set; }
    }

    public class EventChangeReturnPositionState: EventArgs
    {
        public ReturnItemObj Item { get; set; }
    }
}