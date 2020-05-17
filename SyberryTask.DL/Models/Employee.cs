using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyberryTask.DL.Models
{
    public sealed class Employee
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public List<TimeReport> TimeReports { get; set; }
    }
}
