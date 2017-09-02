
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DBContext;
using DAL.Repository.Interfaces;
using ZenOfBeer.BreweryDb.Pcl;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace DAL.Repository.Classes
{
    public class MockBeerDataObjectRepository : BaseRepository<BeerDataObject>, IBeerDataObjectRepository
    {

        public MockBeerDataObjectRepository(IDbContext context) : base(context)
        {

        }

        public override  Task<IResultsContainer<T>> GetData<T>(params KeyValuePair<string, string>[] parameters)
        {

            var s=(T)Convert.ChangeType(new BeerDataObject() {Id="54" }, typeof(T));
            var fake = new ResultsContainer<T> {s };
           var r= Task.FromResult<IResultsContainer<T>>(fake);
            return r;
        }

        public Task<BeerDataObject> GetByID(object id)
        {
            var r = Task.FromResult<BeerDataObject>(new BeerDataObject() {Id  ="55"});
            return r;
        }

  
    }
}