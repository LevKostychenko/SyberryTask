using System;
using System.Collections.Generic;
using System.Linq;
using SyberryTask.DL.Models;
using SyberryTask.DL.Repositories;

namespace SyberryTask.Logic
{
    public class TimeReportLogic : ITimeReportLogic
    {
        private readonly ITimeReportRepository _timeReportRepository;

        private readonly IEmployeeRepositrory _employeeRepositrory;

        public TimeReportLogic(ITimeReportRepository timeReportRepository, IEmployeeRepositrory employeeRepositrory)
        {
            _timeReportRepository = timeReportRepository ?? throw new NullReferenceException(nameof(timeReportRepository));

            _employeeRepositrory = employeeRepositrory ?? throw new NullReferenceException(nameof(employeeRepositrory));
        }

        public SortedDictionary<DayOfWeek, IEnumerable<TimeReport>> GetTopEmployeesForWeek(DateTime fromDate)
        {
            DateTime weekLastDay = GetWeekLastDay(fromDate);

            List<IGrouping<DayOfWeek, TimeReport>> timeReportsForWeek = _timeReportRepository.Get(x => x.Date >= fromDate && x.Date <= weekLastDay).GroupBy(g => g.Date.DayOfWeek).ToList();

            var topEmployeesOfWeek = new SortedDictionary<DayOfWeek, IEnumerable<TimeReport>>();

            foreach (var day in timeReportsForWeek)
            {
                IEnumerable<TimeReport> orderedReports = day.OrderBy(x => x.Hours).Take(3);

                topEmployeesOfWeek.Add(day.Key, orderedReports);
            }

            return topEmployeesOfWeek;
        }

        private DateTime GetWeekLastDay(DateTime fromDate)
        {
            DateTime currentWeekSaturday;

            switch (fromDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    {
                        currentWeekSaturday = fromDate.AddDays(7);
                        break;
                    }
                case DayOfWeek.Sunday:
                    {
                        currentWeekSaturday = fromDate.AddDays(6);
                        break;
                    }
                default:
                    {
                        currentWeekSaturday = fromDate.AddDays(6 - (int)fromDate.DayOfWeek);
                        break;
                    }
            }

            return currentWeekSaturday;
        }
    }
}
