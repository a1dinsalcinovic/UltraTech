using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Tag1 { get; set; }
    public string Tag2 { get; set; }
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool Popust { get; set; }
    public List<string> Galerija { get; set; } = new();
    public List<Recenzija> Recenzije { get; set; } = new();
    public int UkupnaOcjena { get; set; }
}
