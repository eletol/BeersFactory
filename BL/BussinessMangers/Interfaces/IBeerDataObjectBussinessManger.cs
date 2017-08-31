
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.ViewModels;
using ZenOfBeer.BreweryDb.Pcl;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace BL.BussinessMangers.Interfaces
{
    public interface IBeerDataObjectBussinessManger : IBaseBussinessManger<BeerDataObject>
    {
        Task<BaseBeers> GetData(PagingInfo pInfo);
        Task<BeerDataObjectVM> GetByID(object id);
    }
}