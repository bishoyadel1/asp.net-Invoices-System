using Domin.Entity;
using Domin.ViewModel;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepository.ServicesRepository
{
    public class ServicesProduct : IServicesProduct<Product>
    {
        private readonly InvoicesAppDbContext _context;
        public ServicesProduct(InvoicesAppDbContext dbContext) { 
        
        _context= dbContext;
        }

  
        public List<Product> GetProduct(string Id)
        {
            try
            {
                var Product = _context.Products.Where(p => p.CurrentState == 1 && p.CategoryId.Equals(int.Parse(Id))).ToList();
                return Product;
            }
            catch (Exception) { return null; }
        }

        public Product GetProductPrice(string Id)
        {
           try
            {
                return _context.Products.Where(p => p.Id.Equals(int.Parse(Id))).First();
            }
            catch(Exception) { return null; }
        }
    }
}
