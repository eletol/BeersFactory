using System.Data.Entity.Migrations;
using DAL.DBContext;
using Microsoft.AspNet.Identity;

namespace DAL.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DBContext.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.DBContext.MyDbContext context)
        {
            
        }
    }
}
