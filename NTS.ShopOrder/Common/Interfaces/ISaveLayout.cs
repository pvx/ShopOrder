namespace Common.Interfaces
{
    public interface ISaveLayout
    {
        string ViewCode { get; set; }
        void SaveLayout(string data);
        string LoadLayout();
    }
}