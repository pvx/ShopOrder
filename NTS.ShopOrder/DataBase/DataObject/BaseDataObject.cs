using System;

namespace DataBase.DataObject
{
    /// <summary>
    /// Базовый класс объектов данных
    /// </summary>
    public class BaseDataObject
    {
        public Guid Id { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}