using System.Threading.Tasks;
using ZenOfBeer.BreweryDb.Pcl;

namespace DAL.Repository.Interfaces
{
    public interface IBeerDataObjectRepository :IBaseRepository<BeerDataObject>
    {
         new  Task<BeerDataObject> GetByID(object id);
    }
}