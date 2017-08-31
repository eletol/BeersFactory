using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BL.BussinessMangers.Interfaces;
using BL.ViewModels;
using Newtonsoft.Json;
using Ninject;
using ZenOfBeer.BreweryDb.Pcl;
using ZenOfBeer.BreweryDb.Pcl.Public;
using log4net;

namespace BeersFactory.BackEnd.Controllers
{
    [RoutePrefix("api/Beers")]

    public class BeersController : ApiController
    {  
        public IBeerDataObjectBussinessManger BeerDataObjectBussinessManger { get; set; }

        [Inject]
        public BeersController(IBeerDataObjectBussinessManger beerDataObjectBussinessManger)
        {
            BeerDataObjectBussinessManger = beerDataObjectBussinessManger;
        }

        public BeersController()
        {

        }

    

        [Route("GetByFilter")]
        [HttpPost]
        public async Task<BaseBeers> GetByFilter([FromBody] PagingInfo pInfo)
        {
            try
            {
                return await BeerDataObjectBussinessManger.GetData(pInfo);

            }
            catch (Exception e)
            {

                string content = String.Format("\nAn Exception was returned with Message: '{0}'\n and Stack Trace:" +
                          "'{1}'.", e.Message, e.StackTrace);
                LogManager.GetLogger(GetType()).Error(content);
                throw;

            }
        
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<BeerDataObjectVM> GetById(string id)
        {
            try
            {
                return await BeerDataObjectBussinessManger.GetByID(id);

            }
            catch (Exception e)
            {

                string content = String.Format("\nAn Exception was returned with Message: '{0}'\n and Stack Trace:" +
                          "'{1}'.", e.Message, e.StackTrace);
                LogManager.GetLogger(GetType()).Error(content);
                throw;

            }
        }
    }

  
}
