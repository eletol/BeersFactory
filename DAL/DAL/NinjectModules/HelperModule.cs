using DAL.DBContext;
using DAL.UnitOfWork;
using Ninject.Modules;

namespace DAL.NinjectModules
{
    public class HelperModule : NinjectModule
    {
        public override void Load()
        {
            //TODO: Divid them to multiapule modules
            Bind<IUnitOfWork>().To<UnitOfWork<MyDbContext>>();
            Bind<IDbContext>().To<MyDbContext>();
            Bind<UnitOfWork<MyDbContext>>().ToSelf().InSingletonScope();
            Bind<MyDbContext>().ToSelf().InSingletonScope();

        }
    }
}