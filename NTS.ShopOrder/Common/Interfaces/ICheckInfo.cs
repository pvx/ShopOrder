using Common.Enum;

namespace Common.Interfaces
{
    public interface ICheckInfo
    {
        StateCheck GetCheckState();
        void CheckedGoodsByCode(string code);
    }
}