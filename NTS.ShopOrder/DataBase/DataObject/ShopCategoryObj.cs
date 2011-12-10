namespace DataBase.DataObject
{
    /// <summary>
    /// Класс категория магазина
    /// </summary>
    public class ShopCategoryObj
    {
        private string _categoryName;
        private int _id;

        public int Id { get { return _id; } }
        public string CategoryName { get { return _categoryName; } }

        public ShopCategoryObj(string categoryName, int id)
        {
            _categoryName = categoryName;
            _id = id;
        }

        public override string ToString()
        {
            return string.Format("{0}", _categoryName);
        }

    }
}