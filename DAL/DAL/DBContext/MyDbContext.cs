using DAL.DBContext;


namespace DAL.DBContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext, IDbContext
    {
        public MyDbContext()
            : base("name=MyDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }

       
    }
}
