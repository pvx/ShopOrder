using System.Collections.Generic;
using Common.Enum;

namespace Common
{
    /// <summary>
    /// Интерфейс описания пользователя системы
    /// </summary>
    public interface IOrderUserInfo
    {
        string Server { get; set; }
        string DataBase { get; set; }
        string UserName { get; set; }
        string UserPassword { get; set; }
        string Info { get; }
        Dictionary<string, string> Property { get; set; }
        int Permission { get; }
        string ReportFolder { get; set; }
    }
}