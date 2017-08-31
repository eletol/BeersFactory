
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DBContext;
using DAL.Repository.Interfaces;
using ZenOfBeer.BreweryDb.Pcl;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace DAL.Repository.Classes
{
    public class BeerDataObjectRepository : BaseRepository< BeerDataObject>, IBeerDataObjectRepository
    {
        
        public BeerDataObjectRepository(IDbContext context) : base(context)
        {

        }

        public async new Task<BeerDataObject> GetByID(object id)
        {
            var data = await BreweryDbFactory<BeerDataObject>.GetData("aa71e032ef369a484e0b39485e9e8d2b",
                       new KeyValuePair<string, string>("ids",id.ToString()));
            return data.FirstOrDefault();
        }
    }
}