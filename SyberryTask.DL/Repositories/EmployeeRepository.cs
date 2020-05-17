using System;
using SyberryTask.DL.Contexts;
using SyberryTask.DL.Models;
using SyberryTask.DL.Repositories.Base;

namespace SyberryTask.DL.Repositories
{
    public class EmployeeRepository : BaseCompanyRepository<Employee>, IEmployeeRepositrory
    {
        private readonly CompanyContext _companyContext;

        public EmployeeRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext ?? throw new NullReferenceException(nameof(companyContext));
        }
    }
}
