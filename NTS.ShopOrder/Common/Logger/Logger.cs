using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace Common.Logger
{
    /// <summary>
    /// Реализация логгера
    /// </summary>
    public class Logger
    {
        private readonly ILog _log;

        public Logger()
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        #region Implementation of ILog

        public void Error(string message, Exception exception)
        {
            _log.Error(message, exception);
#if DEBUG
            ShowMsg(message + "  " + exception.Message);
#endif
        }

        public void Info(string message)
        {
            _log.Info(message);
        }

        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Fatal(string message, Exception exception)
        {
            _log.Fatal(message, exception);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

        private void ShowMsg(string message)
        {
            MessageBox.Show(message);
        }

        #endregion
    }
}
