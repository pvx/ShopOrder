using System.Collections;
using System.ComponentModel;
using DataBase.DataObject;
using DevExpress.Data;

namespace ShopOrderCustom
{
    public class PreGoodsBalanceData: PreGoodsBalanceObj
    {
        public BindingList<GoodsBalanceObj> _CommitList = new BindingList<GoodsBalanceObj>();

        public BindingList<GoodsBalanceObj> CommitList
        {
            get { return _CommitList; }
        }

        public void AddCommitData(GoodsBalanceObj obj)
        {
            if (obj != null)
            {
                if (_CommitList != null)
                    _CommitList = new BindingList<GoodsBalanceObj>();
                _CommitList.Add(obj);
            }
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