using System;
using System.IO;
using System.Text;
using Common;
using Common.Interfaces;
using DataBase;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Practices.Unity;
using System.Linq;

namespace ShopOrderCustom.Models
{
    public class ModelLayout : ModelBase, ISaveLayout
    {
        private readonly IUnityContainer _unityContainer;

        protected ModelLayout(IUnityContainer container)
        {
            _unityContainer = container;
        }

        private string _viewCode;
        public string ViewCode
        {
            get { return _viewCode; }
            set { _viewCode = value; }
        }

        public void SaveLayout(string data)
        {
            var userId = new Guid(_unityContainer.Resolve<IOrderUserInfo>().Property["USER_ID"]);
            using (var oc = _unityContainer.Resolve<OrderDataContext>())
            {
                oc.DataBaseContext.sp_ins_UserLayout(userId, _viewCode, data);
            }
        }

        public string LoadLayout()
        {
            string ret = string.Empty;

            var userId = new Guid(_unityContainer.Resolve<IOrderUserInfo>().Property["USER_ID"]);
            using (var oc = _unityContainer.Resolve<OrderDataContext>())
            {
                var settings = from vo in oc.DataBaseContext.sp_sel_UserLayout(userId, _viewCode) select vo;

                foreach (sp_sel_UserLayoutResult setting in settings)
                {
                    ret = setting.Setting;
                }
            }
            return ret;
        }

        public void SaveUserViewLayout(ColumnView view)
        {
            try
            {
                var fs = new MemoryStream();
                GridLayoutSerializer.SaveLayout(view, fs);
                byte[] s = fs.ToArray();
                string str = Encoding.UTF8.GetString(s);
                SaveLayout(str.Remove(0, 1));
            }
            catch
            {
            }
        }
        
        public void LoadUserViewLayout(ColumnView view)
        {
            try
            {
                string strl = LoadLayout();
                var mss = new MemoryStream(Encoding.UTF8.GetBytes(strl));
                view.RestoreLayoutFromStream(mss);
            }
            catch
            {
            }
        }
    }
}