using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkAggregator.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter);

    }
}
