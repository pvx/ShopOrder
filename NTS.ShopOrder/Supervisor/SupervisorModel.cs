using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using DataBase;
using Microsoft.Practices.Unity;

namespace Supervisor
{
    public class SupervisorModel
    {
        public IUnityContainer UnityContainer { get; set; }
        public TreeNode NodeList { get; set; }

        [InjectionConstructor]
        public SupervisorModel(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
        }

        public void LoadNodes(TreeView tvView)
        {
            if (tvView == null)
                throw new ArgumentNullException("tvView");
            tvView.Nodes.Clear();using (OrderDataContext oc = UnityContainer.Resolve<OrderDataContext>())
            {
                var shops = (from sh in oc.DataBaseContext.vOrderHeaderAll
                            select new {sh.ShopName, sh.id_Shop, sh.ShopCode }).Distinct();

                foreach (var vOrder in shops)
                {
                    TreeNode tn = tvView.Nodes.Add(vOrder.ShopName);
                    tn.Tag = vOrder.id_Shop;

                    var order = vOrder;
                    var nd = oc.DataBaseContext.vOrderHeaderAll.Where(sh => sh.id_Shop == order.id_Shop).Where(sh=>sh.id_OrderState == 2).OrderBy(sh => sh.CreateDate);
                    foreach (var node in nd)
                    {
                        var nodeTree = new TreeNode(string.Format("{0} [{1}]", node.CreateDate.ToString(), node.Name))
                                           {Tag = node};
                        tn.Nodes.Add(nodeTree);
                    }
                }
 
            }
        }

        public BindingList<vGoodsBalanceOrder> GetOrderList(Type type, object id)
        {
            using (OrderDataContext oc = UnityContainer.Resolve<OrderDataContext>())
            {
                if (type.Equals(typeof (vOrderHeaderAll)))
                {                
                    var orders = from or in oc.DataBaseContext.vGoodsBalanceOrder
                                 where or.id_OrderHeader == ((vOrderHeaderAll)id).id_OrderHeader
                             select or;
                    return new BindingList<vGoodsBalanceOrder>(orders.ToList());
                }
                else
                {
                    var orders = from oh in oc.DataBaseContext.vOrderHeaderAll
                                 join or in oc.DataBaseContext.vGoodsBalanceOrder on oh.id_OrderHeader equals or.id_OrderHeader
                                 //join us in oc.DataBaseContext.User on oh.id_User equals us.id
                                 //join sh in oc.DataBaseContext.Shop on us.id_Shop equals sh.id
                                 where oh.id_Shop == (Guid)id
                                 where oh.id_OrderState == 2select or;
                    return new BindingList<vGoodsBalanceOrder>(orders.ToList());
                }
            
            }
        }

        public BaseView CreateForm()
        {
            return new SupervisorForm(this);
        }
    }
}
