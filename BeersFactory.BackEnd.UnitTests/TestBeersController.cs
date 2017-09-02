using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Threading.Tasks;
using System.Web.Http.Results;
using BeersFactory.BackEnd.Controllers;
using BL.BussinessMangers.Classes;
using BL.BussinessMangers.Interfaces;
using BL.ViewModels;
using DAL.DBContext;
using DAL.Repository.Classes;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.MockingKernel.Moq;
using Ninject.Web.Common;
using ZenOfBeer.BreweryDb.Pcl;

namespace BeersFactory.BackEnd.UnitTests
{
    [TestClass]
    public class TestBeersController
    {
        private readonly MoqMockingKernel _kernel;

        public TestBeersController()
        {
             _kernel = new MoqMockingKernel();
            //_kernel.Bind<IDbContext>().To<MyDbContext>().InRequestScope();
            //_kernel.Bind<IUnitOfWork>().To<UnitOfWork<MyDbContext>>().InRequestScope();
            _kernel.Bind<IBeerDataObjectBussinessManger>().To<BeerDataObjectBussinessManger<IBeerDataObjectRepository>>();

        }
      
        [TestMethod]
        public void GetByFilter_ShouldReturnAllBeers()
        {
            // Set up Prerequisites   

            var uow = _kernel.GetMock<IUnitOfWork>();
                uow.Setup(e => e.Repository<BeerDataObject, IBeerDataObjectRepository>()).Returns(new MockBeerDataObjectRepository(null));
                var bm = _kernel.Get<IBeerDataObjectBussinessManger>();
               BeersController bc = new BeersController(bm);

            // Act  
            var r =  bc.GetByFilter(new PagingInfo() {Order = "",Sort="",Page = "1"}).Result;
            // Assert  
            Assert.AreEqual(r.BeerDataObjectListVM.Count,1);
            
        }
    }
}
