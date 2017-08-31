using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZenOfBeer.BreweryDb.Pcl;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace BL.BussinessMangers.Interfaces
{
    public interface IBaseBussinessManger<TEntity> where TEntity : class
    {
        Task<IResultsContainer<T>> GetData<T>( params KeyValuePair<string, string>[] parameters)
           where T : IBdoBase;
        TEntity GetById(object id);
        TEntity Save(TEntity item);
        TEntity Update(TEntity entityToUpdate);
        TEntity Delete(object id);

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperties);

        List<TEntity> SaveList(List<TEntity> items);
        void DeleteByFilter(Expression<Func<TEntity, bool>> filter);

    }
}