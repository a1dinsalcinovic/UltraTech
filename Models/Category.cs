using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public double ImageWidth { get; set; } = 100; // Default width
        public double ImageHeight { get; set; } = 100; // Default height
        public double ImageScale { get; set; } = 1.0;
    }

}
