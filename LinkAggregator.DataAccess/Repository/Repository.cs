using LinkAggregation.Models;
using LinkAggregator.DataAccess.DBContext;
using LinkAggregator.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkAggregator.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
