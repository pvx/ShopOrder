using System.Collections;
using System.ComponentModel;
using System.Linq;
using DataBase.DataObject;
using DevExpress.Data;

namespace ShopOrderCustom
{
    public class PreGoodsBalanceData: PreGoodsBalanceObj
    {
        public BindingList<GoodsBalanceObj> _CommitList;

        public BindingList<GoodsBalanceObj> CommitList
        {
            get { return GetRowState() == 0 ? null : _CommitList; }
            set { _CommitList = value; }
        }

        public double FactOrder { get { return GetFactOrder(); } }


        public int StateRow
        {
            get { return GetRowState(); }
        }

        private int GetRowState()
        {
            if (_CommitList == null)
                return 2;
            if (_CommitList.Count > 1)
                return 1;

            if ((_CommitList.Count == 1) && (Code == _CommitList[0].Code))
            {
                return 0;
            }
            else
            {
                return 1;
            }

            if (_CommitList.Where(x => x.Code == Code).SingleOrDefault() != null)
                return 0;

            return 2;
        }

        private double GetFactOrder()
        {
            if(_CommitList != null)
            {
                return _CommitList.Sum(x => x.Quantity);
            }
            return 0;
        }

        /*
        public string GetRelationName(int index, int relationIndex)
        {
            return "Commit";
        }

        public bool IsMasterRowEmpty(int index, int relationIndex)
        {
            return false;
        }

        public IList GetDetailList(int index, int relationIndex)
        {
            if (CommitList.Count > 0)
                return CommitList;
            else
                return null;
        }

        public int RelationCount
        {
            get { return 1; }
        }
        */
    }
}