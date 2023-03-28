using MVVMDemo.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVMDemo
{
    public class Repo
    {
        public List<ProductModel> productModel = new List<ProductModel>()
         {
               new ProductModel{Id = 1, Name = "Juicer", Price = 3000},
               new ProductModel{Id = 2,Name = "Mixer", Price = 4000},
               new ProductModel{Id = 3,Name = "Fridge", Price = 15000},
               new ProductModel{Id = 4,Name = "TV", Price = 25000}
         };

        public async Task<ActionResultEventsArgs> SearchProducts(string searchTerm)
        {
            await Task.Delay(3000);
           return ActionResultEventsArgs.Response( productModel.Where(p=>p.Name.ToLower().Contains(searchTerm.ToLower())).ToList());
        }
    }
}