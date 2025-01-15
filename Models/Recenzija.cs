using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Models
{
    public class Recenzija
    {
        public int id { get; set; }
        public string Ime { get; set; }
        public int Ocjena { get; set; }
        public string Komentar { get; set; }
        public int ProductId { get; set; }
    }

}
