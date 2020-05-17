using Microsoft.EntityFrameworkCore;
using SyberryTask.DL.Models;

namespace SyberryTask.DL.Contexts
{
    public sealed class CompanyContext : DbContext
    {
        public DbSet<TimeReport> TimeReports { get; set; }

        public DbSet<Employee> Employees{ get; set; }

        public CompanyContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-PR1QQB5\SQLEXPRESS03;Initial Catalog = Company; Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeReport>()
                .HasOne(p => p.Employee)
                .WithMany(t => t.TimeReports)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TimeReport>()
                .ToTable("time_reports");

            modelBuilder.Entity<Employee>()
                .ToTable("employees");
        }
    }
}
