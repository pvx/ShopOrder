using System.ComponentModel;
using DevExpress.XtraTreeList;

namespace ShopOrders
{
    public class Project
    {
        private string name;
        private Projects owner;
        private Projects projects;
        private bool isTask;

        public Project()
        {
            this.owner = null;
            this.name = "";
            this.isTask = false;
            this.projects = new Projects();
        }

        public Project(string name, bool isTask)
        {
            this.name = name;
            this.isTask = isTask;
            this.projects = new Projects();
        }

        public Project(Projects projects, string name, bool isTask)
            : this(name, isTask)
        {
            this.projects = projects;
        }

        [Browsable(false)]
        public Projects Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public bool IsTask
        {
            get { return isTask; }
            set
            {
                if (isTask == value) return;
                isTask = value;
                OnChanged();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (Name == value) return;
                name = value;
                OnChanged();
            }
        }

        [Browsable(false)]
        public Projects Projects
        {
            get { return projects; }
        }

        private void OnChanged()
        {
            if (owner == null) return;
            int index = owner.IndexOf(this);
            owner.ResetItem(index);
        }
    }

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
            switch (info.Column.Caption)
            {
                case "Name":
                    info.CellData = obj.Name;
                    break;
            }
        }

        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            Project obj = info.Node as Project;
            switch (info.Column.Caption)
            {
                case "Name":
                    obj.Name = (string) info.NewCellData;
                    break;
            }
        }
    }
}