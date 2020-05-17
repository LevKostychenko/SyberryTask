using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SyberryTask.DL.Contexts;

namespace SyberryTask.DL.Repositories.Base
{
    public abstract class BaseCompanyRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CompanyContext _companyContext;

        private readonly DbSet<TEntity> _dbSet;

        public BaseCompanyRepository(CompanyContext companyContext)
        {
            _companyContext = companyContext ?? throw new NullReferenceException(nameof(companyContext));

            _dbSet = companyContext.Set<TEntity>();
        }

        public virtual void Add(TEntity record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            _dbSet.Add(record);
            _companyContext.SaveChanges();
        }

        public virtual async Task AddAsync(TEntity record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            await _dbSet.AddAsync(record);
            await _companyContext.SaveChangesAsync();
        }

        public virtual void Edit(TEntity record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            _dbSet.Update(record);
            _companyContext.SaveChanges();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async virtual Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Remove(TEntity record)
        {
            if (record == null)
            {
                throw new ArgumentNullException(nameof(record));
            }

            if (_companyContext.Entry(record).State == EntityState.Detached)
            {
                _dbSet.Attach(record);
            }

            _dbSet.Remove(record);
        }

        public virtual void Remove(int id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }
    }
}
