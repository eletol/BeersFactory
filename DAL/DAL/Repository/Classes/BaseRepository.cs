using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.DBContext;
using DAL.Repository.Interfaces;
using ZenOfBeer.BreweryDb.Pcl;
using ZenOfBeer.BreweryDb.Pcl.Public;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DAL.Repository.Classes
{
    public class BaseRepository<TItem> : IBaseRepository<TItem> where TItem : class, new()

    {
        public static readonly string APIKey = ConfigurationManager.AppSettings["BreweryDb.APIKey"];
        private IDbContext _context { get; set; }

        public BaseRepository(IDbContext context)
        {
            _context = context;

        }
        public virtual async Task<IResultsContainer<T>> GetData<T>(params KeyValuePair<string, string>[] parameters) where T : IBdoBase
        {
            var data = await BreweryDbFactory<T>.GetData(APIKey, parameters);
            return data;
        }
        private DbSet<TItem> dbSet;
        protected IDbContext ContextObject
        {
            get { return _context; }
            set
            {
                _context = value;
                dbSet = ContextObject.Set<TItem>();
            }
        }
        public virtual IQueryable<TItem> Get(
            Expression<Func<TItem, bool>> filter = null,
            Func<IQueryable<TItem>, IOrderedQueryable<TItem>> orderBy = null,
            params Expression<Func<TItem, object>>[] includeProperties)
        {
            IQueryable<TItem> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;
        }

        public virtual TItem GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public TItem Insert(TItem entity)
        {
            return dbSet.Add(entity);
        }
        public List<TItem> InsertList(List<TItem> entities)
        {
            return dbSet.AddRange(entities).ToList();
        }
        public void InsertOrEdit(TItem entity)
        {
            dbSet.AddOrUpdate(entity);
        }
        public virtual TItem Delete(object id)
        {
            var entityToDelete = dbSet.Find(id);
            return Delete(entityToDelete);
        }
        public virtual void DeleteByFilter(Expression<Func<TItem, bool>> filter)
        {
            IQueryable<TItem> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            dbSet.RemoveRange(query);

        }
        public virtual TItem Delete(TItem entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            return dbSet.Remove(entityToDelete);
        }

        public virtual TItem Update(TItem entityToUpdate)
        {
            var entity = dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entity;
        }
    }
}