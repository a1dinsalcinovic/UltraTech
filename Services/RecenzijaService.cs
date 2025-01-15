using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Models;

namespace TechShop.Services
{
    internal class RecenzijaService
    {
        public void AddRecenzija(Recenzija recenzija)
        {
            using (var context = new ProductContext())
            {
                context.Recenzije.Add(recenzija);
                context.SaveChanges();
            }
        }

    }
}
