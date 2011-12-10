using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using DataBase.Repository;
using DevExpress.XtraEditors;
using Microsoft.Practices.Unity;
using ShopOrderCustom;
using ShopOrderCustom.Models;
using ShopOrderLogin;

namespace ShopOrders
{
    /// <summary>
    /// Модель данных UI главного окна программы
    /// </summary>
    public class MainModel : ModelBase
    {
        public IUnityContainer UnityContainer { get; set; }

        private readonly Dictionary<Type, Func<ModelBase>> _modelDict = new Dictionary<Type, Func<ModelBase>>();

        private OrderModel _orderModel;
        private OrderManagerModel _orderManagerModel;
        private AssortmentModel _assortmentModel;
        private MinOrderModel _minOrderModel;
        private AssortForOrderModel _assortForOrderModel;
        private UserManagerModel _userManagerModel;
        private OrderViewerModel _orderViewerModel;
        private ActualAssortViewerModel _actualAssortViewerModel;
        private BalanceEditorModel _balanceEditorModel;

        private XtraForm _view;
        public XtraForm View
        {
            get
            {
                if (_view == null)
                    return _view = new MainForm(this);

                return _view;}
            set
            {
                if (_view == null)
                    _view = value;
            }
        }

        [InjectionConstructor]
        public MainModel(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;

            _modelDict.Add(typeof(OrderModel), () => UnityContainer.Resolve<OrderModel>());
            _modelDict.Add(typeof(OrderManagerModel), () => UnityContainer.Resolve<OrderManagerModel>());
            _modelDict.Add(typeof(AssortmentModel), () => UnityContainer.Resolve<AssortmentModel>());
            _modelDict.Add(typeof(MinOrderModel), () => UnityContainer.Resolve<MinOrderModel>());
            _modelDict.Add(typeof(AssortForOrderModel), () => UnityContainer.Resolve<AssortForOrderModel>());
            _modelDict.Add(typeof(UserManagerModel), () => UnityContainer.Resolve<UserManagerModel>());
            _modelDict.Add(typeof(OrderViewerModel), () => UnityContainer.Resolve<OrderViewerModel>());
            _modelDict.Add(typeof(ActualAssortViewerModel), () => UnityContainer.Resolve<ActualAssortViewerModel>());
            _modelDict.Add(typeof(BalanceEditorModel), () => UnityContainer.Resolve<BalanceEditorModel>());  
        }

        public void ShowForm(Type typeModel)
        {
            if (typeModel.Equals(typeof(BalanceEditorModel)))
            {
                if (_balanceEditorModel == null)
                {
                    _balanceEditorModel = (BalanceEditorModel)_modelDict[typeModel].Invoke();
                    _balanceEditorModel.View.MdiParent = View;
                    _balanceEditorModel.View.WindowState = FormWindowState.Maximized;
                    _balanceEditorModel.View.Show();
                    _balanceEditorModel.View.FormClosed += new FormClosedEventHandler(BalanceEditorModelFormClosed);
                }
                else
                {
                    _balanceEditorModel.View.BringToFront();
                }
            }

            if (typeModel.Equals(typeof(ActualAssortViewerModel)))
            {
                if (_actualAssortViewerModel == null)
                {
                    _actualAssortViewerModel = (ActualAssortViewerModel)_modelDict[typeModel].Invoke();
                    _actualAssortViewerModel.View.MdiParent = View;
                    _actualAssortViewerModel.View.WindowState = FormWindowState.Maximized;
                    _actualAssortViewerModel.View.Show();
                    _actualAssortViewerModel.View.FormClosed += new FormClosedEventHandler(AssortViewerFormClosed);
                }
                else
                {
                    _actualAssortViewerModel.View.BringToFront();
                }
            }

            if (typeModel.Equals(typeof(OrderViewerModel)))
            {
                if (_orderViewerModel == null)
                {
                    _orderViewerModel = (OrderViewerModel)_modelDict[typeModel].Invoke();
                    _orderViewerModel.View.MdiParent = View;
                    _orderViewerModel.View.WindowState = FormWindowState.Maximized;
                    _orderViewerModel.View.Show();
                    _orderViewerModel.View.FormClosed += new FormClosedEventHandler(OrderViewerModelClose);
                }
                else
                {
                    _orderViewerModel.View.BringToFront();
                }
            }

            if (typeModel.Equals(typeof(AssortForOrderModel)))
            {
                if (_assortForOrderModel == null)
                {
                    _assortForOrderModel = (AssortForOrderModel)_modelDict[typeModel].Invoke();
                    _assortForOrderModel.View.MdiParent = View;
                    _assortForOrderModel.View.WindowState = FormWindowState.Maximized;
                    _assortForOrderModel.View.Show();
                    _assortForOrderModel.View.FormClosed += new FormClosedEventHandler(AssortForOrderCloser);
                }
                else
                {
                    _assortForOrderModel.View.BringToFront();
                }
            }

            if(typeModel.Equals(typeof(OrderModel)))
            {
                if (_orderModel == null)
                {
                    _orderModel = (OrderModel) _modelDict[typeModel].Invoke();
                    _orderModel.View.MdiParent = View;
                    _orderModel.View.WindowState = FormWindowState.Maximized;
                    _orderModel.View.Show();
                    _orderModel.View.FormClosed += new FormClosedEventHandler(OrderCloser);
                }
                else
                {
                    _orderModel.View.BringToFront();
                }
            }

            if (typeModel.Equals(typeof(OrderManagerModel)))
            {
                if (_orderManagerModel == null)
                {
                    _orderManagerModel = (OrderManagerModel)_modelDict[typeModel].Invoke();
                    _orderManagerModel.View.MdiParent = View;
                    _orderManagerModel.View.WindowState = FormWindowState.Maximized;
                    _orderManagerModel.View.Show();
                    _orderManagerModel.View.FormClosed += new FormClosedEventHandler(OrderManagerClose);
                }
                else
                {
                    _orderManagerModel.View.BringToFront();
                }
            }

            if (typeModel.Equals(typeof(AssortmentModel)))
            {
                if (_assortmentModel == null)
                {
                    _assortmentModel = (AssortmentModel) _modelDict[typeModel].Invoke();
                    _assortmentModel.View.MdiParent = View;
                    _assortmentModel.View.WindowState = FormWindowState.Maximized;
                    _assortmentModel.View.Show();
                    _assortmentModel.View.FormClosed += new FormClosedEventHandler(AssortClose);
                }
                else
                {
                    _assortmentModel.View.BringToFront();
                }
            }
            if (typeModel.Equals(typeof(MinOrderModel)))
            {
                if (_minOrderModel == null)
                {
                    _minOrderModel = (MinOrderModel)_modelDict[typeModel].Invoke();
                    _minOrderModel.View.MdiParent = View;
                    _minOrderModel.View.WindowState = FormWindowState.Maximized;
                    _minOrderModel.View.Show();
                    _minOrderModel.View.FormClosed += new FormClosedEventHandler(MinOrderClose);
                }
                else
                {
                    _minOrderModel.View.BringToFront();
                }
            }

            if (typeModel.Equals(typeof(UserManagerModel)))
            {
                if (_userManagerModel == null)
                {
                    _userManagerModel = (UserManagerModel)_modelDict[typeModel].Invoke();
                    _userManagerModel.View.MdiParent = View;
                    _userManagerModel.View.WindowState = FormWindowState.Maximized;
                    _userManagerModel.View.Show();
                    _userManagerModel.View.FormClosed += new FormClosedEventHandler(UserManagerClose);
                }
                else
                {
                    _userManagerModel.View.BringToFront();
                }
            }
        }

        private void BalanceEditorModelFormClosed(object sender, FormClosedEventArgs e)
        {
            _balanceEditorModel = null;}

        void AssortViewerFormClosed(object sender, FormClosedEventArgs e)
        {
            _actualAssortViewerModel = null;
        }

        void OrderViewerModelClose(object sender, FormClosedEventArgs e)
        {
            _orderViewerModel = null;
        }

        void UserManagerClose(object sender, FormClosedEventArgs e)
        {
            _userManagerModel = null;
        }

        void AssortForOrderCloser(object sender, FormClosedEventArgs e)
        {
            _assortForOrderModel = null;
        }

        void MinOrderClose(object sender, FormClosedEventArgs e)
        {
            _minOrderModel = null;
        }

        void AssortClose(object sender, FormClosedEventArgs e)
        {
            _assortmentModel = null;
        }

        void OrderManagerClose(object sender, FormClosedEventArgs e)
        {
            _orderManagerModel = null;
        }

        void OrderCloser(object sender, FormClosedEventArgs e)
        {
            _orderModel = null;
        }

        public bool Login()
        {
            using (var loginModel = UnityContainer.Resolve<LoginModel>())
            {
                if (loginModel.View.ShowDialog() != DialogResult.OK)
                {
                    View.Close();
                    return false;
                }
            }
            return true;
        }
    }
}