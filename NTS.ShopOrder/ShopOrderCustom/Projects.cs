using System;
using System.ComponentModel;
using DevExpress.XtraTreeList;

namespace ShopOrderCustom
{
    public class Projects : BindingList<Project>, TreeList.IVirtualTreeListData
    {
        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            Project obj = info.Node as Project;
            info.Children = obj.Projects;
        }

        protected override void InsertItem(int index, Project item)
        {
            item.Owner = this;
            base.InsertItem(index, item);
        }

        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            Project obj = info.Node as Project;
            switch (info.Column.FieldName)
            {
                case "Name":
                    info.CellData = obj.Name;
                    break;
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            info.Cancel = true;/*
            Project obj = info.Node as Project;
            switch (info.Column.Caption)
            {
                case "Name":
                    obj.Name = (string)info.NewCellData;
                    break;
            }
             * */}
    }
}