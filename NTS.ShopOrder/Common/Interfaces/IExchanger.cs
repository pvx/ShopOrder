using System;

namespace Common.Interfaces
{
    public interface IExchanger
    {
        object Get();
        void Set(object o);
        Type ObjType();
    }
}