using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataBase;
using DataBase.DataObject;
using DevExpress.XtraEditors;
using ShopOrderLogin.Data;

namespace ShopOrderLogin
{
    public partial class UserManagerForm : XtraForm
    {
        private UserManagerModel Model {get; set;}
        private UserObj _currentUserObj;

        public UserManagerForm(UserManagerModel model)
        {
            Model = model;
            InitializeComponent();
            InitTreeListControl();
        }

        private void InitTreeListControl()
        {
            DataBinding();
        }

        private void DataBinding()
        {
            treeList.ExpandAll();
            treeList.DataSource = Model.UserList;
            treeList.BestFitColumns();

            cbListPermis.DisplayMember = "Name";
            cbListPermis.DataSource = Model.UserList.GetPermissionsList();
        }

        void SetCheck(int permis)
        {
            if(cbListPermis.DataSource != null)
            {
                var list = (BindingList<sp_sel_OperationPermissionsResult>)cbListPermis.DataSource;
                foreach (var item in list)
                {
                    bool b = (permis & item.bitcode) == item.bitcode;
                    cbListPermis.SetItemChecked(cbListPermis.FindItem(item), b);
                }
            }
        }

        private void SavePermission()
        {
            if((cbListPermis.DataSource != null) && (_currentUserObj != null))
            {
                int permiss = 0;

                var list = (BindingList<sp_sel_OperationPermissionsResult>)cbListPermis.DataSource;
                foreach (var item in list)
                {
                    if(cbListPermis.GetItemChecked(cbListPermis.FindItem(item)))
                    {
                        permiss += item.bitcode;    
                    }
                }
                _currentUserObj.Permissions = permiss;
                Model.Save(_currentUserObj);
            }
        }

        void BindControls(UserObj uo)
        {
            edLogin.DataBindings.Clear();
            edLogin.DataBindings.Add(new Binding("Text", uo, "UserLogin"));

            edPassword.DataBindings.Clear();
            edPassword.DataBindings.Add(new Binding("Text", uo, "UserPassword"));

            edName.DataBindings.Clear();
            edName.DataBindings.Add(new Binding("Text", uo, "UserName"));

            cbActive.DataBindings.Clear();
            cbActive.DataBindings.Add(new Binding("Checked", uo, "Active"));
            SetCheck(uo.Permissions);
            btSavePermiss.Enabled = true;
        }

        private void TreeListAfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node != null)
            {
                _currentUserObj = ((Users)e.Node.TreeList.DataSource)[e.Node.Id];
                BindControls(_currentUserObj);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SavePermission();
        }
    }
}