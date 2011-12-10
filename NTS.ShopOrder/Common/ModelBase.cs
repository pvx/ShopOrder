using System;
using Common.Interfaces;

namespace Common
{
    /// <summary>
    /// Базовый класс модели UI
    /// </summary>
    public abstract class ModelBase : IDisposable
    {

        public virtual void Dispose()
        {
            
        }
    }
}