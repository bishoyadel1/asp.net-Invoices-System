using Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.ViewModel
{
    public class BayInvoiceViewModel
    {
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public Invoice Invoice { get; set; } = new Invoice();
    }

    public class ProductsCategorey
    {
        public string? CategoryName { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        

    }

}
