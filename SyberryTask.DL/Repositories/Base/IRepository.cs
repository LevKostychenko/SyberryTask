using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SyberryTask.DL.Repositories.Base
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        void Add(T record);

        Task AddAsync(T record);

        void Remove(T record);

        void Remove(int id);

        void Edit(T record);
    }
}
