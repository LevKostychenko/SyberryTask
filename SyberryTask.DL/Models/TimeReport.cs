using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SyberryTask.DL.Models
{
    public sealed class TimeReport
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("employee_id ")]
        public int EmployeeId { get; set; }

        [Column("hours")]
        public float Hours { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        public Employee Employee { get; set; }
    }
}
