using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SyberryTask.DL.Contexts;
using SyberryTask.DL.Models;
using SyberryTask.DL.Repositories.Base;

namespace SyberryTask.DL.Repositories
{
    public sealed class TimeReportRepository : BaseCompanyRepository<TimeReport>, ITimeReportRepository
    {
        private readonly CompanyContext _companyContext;

        public TimeReportRepository(CompanyContext companyContext) : base(companyContext)
        {
            _companyContext = companyContext ?? throw new NullReferenceException(nameof(companyContext));
        }

        public override IEnumerable<TimeReport> GetAll()
        {
            return _companyContext.TimeReports.Include(c => c.Employee);
        }

        public override IEnumerable<TimeReport> Get(Expression<Func<TimeReport, bool>> filter = null, Func<IQueryable<TimeReport>, IOrderedQueryable<TimeReport>> orderBy = null)
        {
            IQueryable<TimeReport> query = _companyContext.TimeReports;

            if (filter != null)
            {
                query = query.Where(filter).Include(p => p.Employee);
            }

            if (orderBy != null)
            {
                return orderBy(query).Include(p => p.Employee).ToList();
            }
            else
            {
                return query.Include(p => p.Employee).ToList();
            }
        }
    }
}
