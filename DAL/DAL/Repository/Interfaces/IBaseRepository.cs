using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZenOfBeer.BreweryDb.Pcl;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace DAL.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IResultsContainer<T>> GetData<T>( params KeyValuePair<string, string>[] parameters)
            where T : IBdoBase;
        IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetByID(object id);
        TEntity Insert(TEntity entity);
        List<TEntity> InsertList(List<TEntity> entity);

        void InsertOrEdit(TEntity entity);
        TEntity Delete(object id);
        TEntity Delete(TEntity entityToDelete);
        TEntity Update(TEntity entityToUpdate);
        void DeleteByFilter(Expression<Func<TEntity, bool>> filter);
    }
}