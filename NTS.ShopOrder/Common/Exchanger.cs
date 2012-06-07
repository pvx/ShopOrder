using System;
using Common.Interfaces;

namespace Common
{
    public class Exchanger : IExchanger
    {
        private dynamic _object;
        private Type _type;

        public object Get()
        {
            var tmo = _object;
            _object = null;
            return tmo;
        }

        public void Set(object o)
        {
            _type = o.GetType();
            _object = o;
        }

        public Type ObjType()
        {
            throw new NotImplementedException();
        }
    }
}