using System;

namespace DataBase.DataObject
{
    [Obsolete]
    public class OrderHeaderObject : BaseDataObject
    {
        public OrderHeaderObject()
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;
        }

        public OrderHeaderObject(Guid id, DateTime dateTime, int state)
        {
            Id = id;
            OrderDate = dateTime;
            State = state;
        }

        public DateTime ? OrderDate { get; set; }
        public DateTime ? ProcessOrderDate { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }

        public override string ToString()
        {
            return string.Format("Заказ от {0} [{1}]", OrderDate.ToString(), StateName);
        }
        
    }
}