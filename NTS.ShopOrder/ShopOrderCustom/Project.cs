using System.ComponentModel;

namespace ShopOrderCustom
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


}