namespace DataBase.Log
{
    public interface IDBLogger
    {
        void InsertLog(string message, string docId);
    }
}