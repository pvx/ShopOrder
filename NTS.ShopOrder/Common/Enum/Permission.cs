using System;

namespace Common.Enum
{
    /// <summary>
    /// Перечисление доступов к задачам
    /// </summary>
    [Flags]
    public enum Permission
    {   
        EditMinOrder = 1,
        CreateOrder = 2,
        ProcessOrders = 4,
        EditReqAssort = 8,
        EditAssortForOrder = 6,
        ViewOrders = 32,
        ViewActualAssort = 64,
        EditUsers = 128,
        EditBalance = 256,
        ReportView = 512,
        CreateReturn = 1024,
        CreateReturnSt = 2048,
        DistributionGoods = 4096
    }
}
