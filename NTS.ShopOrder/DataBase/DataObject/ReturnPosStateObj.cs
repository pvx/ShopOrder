namespace DataBase.DataObject
{
    public class ReturnPosStateObj : NotifyDataObjectBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StateCode { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}