using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SyberryTask.DL.Contexts;
using SyberryTask.DL.Models;
using SyberryTask.DL.Repositories;
using SyberryTask.Logic;
using SyberryTask.Logic.Extensions;

namespace SyberryTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddDbContext<CompanyContext>()
                .AddSingleton<IEmployeeRepositrory, EmployeeRepository>()
                .AddSingleton<ITimeReportRepository, TimeReportRepository>()
                .AddSingleton<ITimeReportLogic, TimeReportLogic>()
           .BuildServiceProvider();

            Console.WriteLine("Enter a start date to search top users (e.g. 12/02/2019): ");
            DateTime startDate = new DateTime();
            bool isInutCorrect = false;

            while (!isInutCorrect)
            {
                if (DateTime.TryParse(Console.ReadLine(), out startDate))
                {
                    isInutCorrect = true;
                }
                else
                {
                    Console.WriteLine("Input incorrect, enter correct date format MM-DD-YYYYY (e.g. 12/02/2019): ");
                }
            }

            SortedDictionary<DayOfWeek, IEnumerable<TimeReport>> topEmployees = serviceProvider.GetService<ITimeReportLogic>()
                .GetTopEmployeesForWeek(startDate);

            if (topEmployees.Count == 0)
            {
                Console.WriteLine("Threa are no time reports for this week.");
            }

            foreach (var day in topEmployees)
            {
                var stringToOutput = new StringBuilder($"| {day.Key.EnumToString()} |");

                foreach (var employee in day.Value)
                {
                    stringToOutput.Append($" {employee.Employee.Name} ({employee.Hours.ToString()} hours), ");
                }

                stringToOutput.Remove(stringToOutput.Length - 2, 2);
                Console.WriteLine(stringToOutput);
            }

            Console.ReadKey();
        }
    }
}
