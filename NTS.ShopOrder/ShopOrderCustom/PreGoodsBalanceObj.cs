using System.ComponentModel;
using System.Linq;
using DataBase.DataObject;

namespace ShopOrderCustom
{
    public class PreGoodsBalanceData: PreGoodsBalanceObj
    {
        private BindingList<GoodsBalanceObj> _commitList;

        public BindingList<GoodsBalanceObj> CommitList
        {
            get { return GetRowState() == 0 ? null : _commitList; }
            set { _commitList = value; }
        }

        public double FactOrder { get { return GetFactOrder(); } }

        public int StateRow
        {
            get { return GetRowState(); }
        }

        private int GetRowState()
        {
            if (_commitList == null)
                return 2;
            if (_commitList.Count > 1)
                return 1;

            if ((_commitList.Count == 1) && (Code == _commitList[0].Code))
            {
                return 0;
            }
            else
            {
                return 1;
            }

            if (_commitList.Where(x => x.Code == Code).SingleOrDefault() != null)
                return 0;

            return 2;
        }

        private double GetFactOrder()
        {
            if(_commitList != null)
            {
                return _commitList.Sum(x => x.Quantity);
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