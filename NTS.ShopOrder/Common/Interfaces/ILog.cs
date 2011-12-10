using System;

namespace Common.Interfaces
{
    public interface ILog
    {
        void Error(string message, Exception exception);

        void Info(string message);

        void Debug(string message);

        void Fatal(string message, Exception exception);

        void Warn(string message);
    }
}