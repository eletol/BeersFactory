using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenOfBeer.BreweryDb.Pcl.Public;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var styles = BreweryDbFactory<IStyle>.GetData("aa71e032ef369a484e0b39485e9e8d2b");
            styles.Wait();
        }
    }
}
