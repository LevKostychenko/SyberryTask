using System.Collections.Generic;
using SyberryTask.DL.Models;
using System;

namespace SyberryTask.Logic
{
    public interface ITimeReportLogic
    {
        SortedDictionary<DayOfWeek, IEnumerable<TimeReport>> GetTopEmployeesForWeek(DateTime fromDate);
    }
}
