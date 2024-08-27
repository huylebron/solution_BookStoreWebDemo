using BanSach.DataAccess.Data;
using BanSach.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BanSach.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.ShoppingCarts.AsNoTracking()
            //_db.ShoppingCarts.Include(u=>u.ProductId);

            this.DbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        // include category,covertype
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter=null, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter!=null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(','))
                {
                    query = query.Include(item);
                }

            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null,bool tracked=true)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = DbSet;
            }
            else
            {
                query=DbSet.AsNoTracking();
            }
           

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(','))
                {
                    query = query.Include(item);
                }

            }
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}
