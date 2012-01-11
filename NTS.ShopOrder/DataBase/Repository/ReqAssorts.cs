using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using DataBase.DataObject;
using Microsoft.Practices.Unity;

namespace DataBase.Repository
{
    /// <summary>
    /// Класс списка позиций товаров для формы оязательного ассортимента
    /// </summary>
    public class ReqAssorts : BindingList<ReqAssortObj>
    {
        private IUnityContainer unityContainer { get; set; }
        private int _idCategory;

        [InjectionConstructor]
        public ReqAssorts(IUnityContainer container)
        {
            unityContainer = container;
            //Load();
        }

        static ReqAssort SaveAsort(ReqAssortObj obj)
        {
            return new ReqAssort()
                       {
                           Code = obj.Code,
                           id_ShopCategory = obj.ShopCategory,
                           id = Guid.NewGuid(),
                           Date = DateTime.Now
                       };
        }

        public bool CheckedGoodsByCode(string code)
        {
            bool check = false;
            try
            {
                ReqAssortObj obj = Items.Where(c => c.Code == code).SingleOrDefault();
                if (obj != null)
                {
                    obj.ReqAssort = true;
                    check = true;
                }
            }
            catch (Exception){ }
            return check;
        }

        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public bool Save()
        {
            bool res = false;
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                DbConnection con = oc.DataBaseContext.Connection;
                try
                {
                    con.Open();
                    oc.DataBaseContext.Transaction = con.BeginTransaction();

                    oc.DataBaseContext.sp_del_ReqAssort(_idCategory);

                    foreach (ReqAssortObj reqAssortObj in Items)
                    {
                        if (reqAssortObj.ReqAssort)
                        {
                            oc.DataBaseContext.sp_ins_ReqAssort(reqAssortObj.Code, _idCategory);
                        }
                    }
                    oc.DataBaseContext.Transaction.Commit();
                    res = true;
                }
                catch (Exception)
                {
                    if (oc.DataBaseContext.Transaction != null)
                        oc.DataBaseContext.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            return res;
        }

        public void Load(int idCategory)
        {
            _idCategory = idCategory;
            using (var oc = unityContainer.Resolve<OrderDataContext>())
            {
                var assort = from m in oc.DataBaseContext.sp_sel_ReqAssort(_idCategory)
                             //where (m.id_ShopCategory == 0 || m.id_ShopCategory == idCategory)
                               select new ReqAssortObj()
                                          {
                                           Barcode = m.Barcode,
                                           Code = m.Code,
                                           Group = m.Group,
                                           Measure = m.Measure,
                                           Name = m.Name,
                                           Price = m.Price.GetValueOrDefault(0),
                                           QuantityInPack = m.QuantityInPack.GetValueOrDefault(0),
                                           Supplier = m.Supplier,
                                           MinOrder = m.MinOrder,
                                           ReqAssort = m.Checked.Equals(1),
                                           ShopCategory = idCategory,// m.id_ShopCategory,
                                           Active = true
                                          };
                Clear();
                foreach (ReqAssortObj assortObj in assort)
                {
                    Add(assortObj);
                    assortObj.ChangeReqAssort += new ChangeReqAssortObj(assortObj_ChangeReqAssort);
                }

            }
        }

        void assortObj_ChangeReqAssort(object sender, EventChangeReqAssortObj e)
        {
            
        }

    }
}