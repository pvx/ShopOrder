using System;
using System.ComponentModel;

namespace DataBase.DataObject
{
    public class EventGoodsNodeCheck : EventArgs
    {
        public GoodsNodeObjBase GoodsNode { get; set; }
    }

    public delegate void GoodsNodeCheck(object sender, EventGoodsNodeCheck e);
    
    /// <summary>
    /// Базовый класс записи для дерева
    /// </summary>
    public class GoodsNodeObjBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs EmptyChangingEventArgs =
            new PropertyChangingEventArgs(String.Empty);

        private Guid _id;
        private int _idInt;
        private string _name;
        private bool _active;
        private string _note;
        private string _idSap;
        private int? _parentId;
        private bool _check;

        public Object ObjectList { get; set; }

        protected virtual void AfterNodeCheck(bool check)
        {
            
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                if ((_id != value))
                {
                    //this.OnidChanging(value);
                    SendPropertyChanging();
                    _id = value;
                    SendPropertyChanged("Id");
                    //this.OnidChanged();
                }
            }
        }

        public int IdInt
        {
            get { return _idInt; }
            set
            {
                if ((_idInt != value))
                {
                    //this.Onid_intChanging(value);
                    SendPropertyChanging();
                    _idInt = value;
                    SendPropertyChanged("IdInt");
                    //this.Onid_intChanged();
                }
            }
        }

        public override string ToString()
        {
            return _name;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if ((_name != value))
                {
                    //this.OnnameChanging(value);
                    SendPropertyChanging();
                    _name = value;
                    SendPropertyChanged("Name");
                    //this.OnnameChanged();
                }
            }
        }

        public bool Active
        {
            get { return _active; }
            set
            {
                if ((_active != value))
                {
                    SendPropertyChanging();
                    _active = value;
                    SendPropertyChanged("Active");
                }
            }
        }

        public bool Check
        {
            get { return _check; }
            set
            {
                if ((_check != value))
                {
                    SendPropertyChanging();
                    _check = value;                   
                    SendPropertyChanged("Check");
                    AfterNodeCheck(_check);
                }
            }
        }

        public string Note
        {
            get { return _note; }
            set
            {
                if ((_note != value))
                {
                    //this.OnnoteChanging(value);
                    SendPropertyChanging();
                    _note = value;
                    SendPropertyChanged("Note");
                    //this.OnnoteChanged();
                }
            }
        }

        public string IdSap
        {
            get { return _idSap; }
            set
            {
                if ((_idSap != value))
                {
                    //this.Onid_sapChanging(value);
                    SendPropertyChanging();
                    _idSap = value;
                    SendPropertyChanged("IdSap");
                    //this.Onid_sapChanged();
                }
            }
        }

        public int? ParentId 
        {
            get { return _parentId; }
            set
            {
                if ((_parentId != value))
                {
                    //this.Ongoods_gen0_idChanging(value);
                    SendPropertyChanging();
                    _parentId = value;
                    SendPropertyChanged("ParentId");
                    //this.Ongoods_gen0_idChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        public event GoodsNodeCheck NodeCheck;

        protected virtual void SendChangeReqQuantity()
        {
            if ((NodeCheck != null))
            {
                NodeCheck(this, new EventGoodsNodeCheck() { GoodsNode = this });
            }
        }
        protected virtual void SendPropertyChanging()
        {
            if ((PropertyChanging != null))
            {
                PropertyChanging(this, EmptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}