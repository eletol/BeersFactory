
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using BL.BussinessMangers.Interfaces;
using BL.ViewModels;
using DAL;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using ZenOfBeer.BreweryDb.Pcl;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace BL.BussinessMangers.Classes
{
    public class BeerDataObjectBussinessManger
        <TRepository> : BaseBussinessManger<BeerDataObject, TRepository>,
            IBeerDataObjectBussinessManger where TRepository : IBeerDataObjectRepository
    {
        public IMapper Mapper { get; set; }
        public TRepository CurrentRepository { get; set; }

        public BeerDataObjectBussinessManger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<IBeer, BeerDataObjectVM>();
                cfg.CreateMap<IBeer, BeerDataObjectListVM>();

            });
             Mapper = config.CreateMapper();
            CurrentRepository = UnitOfWork.Repository<BeerDataObject, TRepository>();

        }
        public async Task<BaseBeers> GetData(PagingInfo pInfo) 
        {
         
            pInfo.filters.Add(new KeyValuePair<string, string>("order", pInfo.Order));
             pInfo.filters.Add(new KeyValuePair<string, string>("sort", pInfo.Sort));
             pInfo.filters.Add( new KeyValuePair<string, string>("p", pInfo.Page));

            var data = await GetData<IBeer>(pInfo.filters.ToArray());
          

            var dest = Mapper.Map<IResultsContainer<IBeer>, List<BeerDataObjectListVM>>(data);
            var baseBeers = new BaseBeers()
            {
                BeerDataObjectListVM = dest,
                CurrentPage = data.CurrentPage,
                ErrorMessage = data.ErrorMessage,
                Message = data.Message,
                NumberOfPages = data.NumberOfPages,
                Status = data.Status,
                TotalResults = data.TotalResults

            };
            return baseBeers;
        }

        public async Task<BeerDataObjectVM> GetByID(object id)
        {
           var data= await CurrentRepository.GetByID(id);
            var dest = Mapper.Map<IBeer,  BeerDataObjectVM>(data);
            return dest;

        }

        

    }
}