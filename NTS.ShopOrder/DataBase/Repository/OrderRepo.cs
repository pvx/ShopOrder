using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Common;
using DataBase.DataObject;
using Microsoft.Practices.Unity;

namespace DataBase.Repository
{
    [Obsolete]
    public class OrderRepo
    {
       // private TreeView _treeView;

        [Dependency]
        public IUnityContainer UnityContainer { get; set; }

        public List<OrderHeaderObject> OrderHeaderObjectList { get; set; }

        private OrderDataContext _orderDataContext;

        public void Load()
        {
            using (_orderDataContext = UnityContainer.Resolve<OrderDataContext>())
            {
                var qr = from c in _orderDataContext.DataBaseContext.OrderHeader
                         join st in _orderDataContext.DataBaseContext.OrderState on c.id_OrderState equals st.id 
                         where c.CreateDate.Date == DateTime.Now.Date
                         select new OrderHeaderObject() 
                         { 
                             Id = c.id, 
                             OrderDate = c.CreateDate, 
                             ProcessOrderDate = c.ProcesDate, 
                             State = c.id_OrderState.GetValueOrDefault(), 
                             StateName = st.Name
                         };
                OrderHeaderObjectList = qr.ToList();
            }      
        }

    }
}