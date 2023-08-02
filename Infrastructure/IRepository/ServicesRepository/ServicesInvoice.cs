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
    public class ServicesInvoice : IServicesInvoice<BayInvoiceViewModel>
    {
        private readonly InvoicesAppDbContext _context;
        public ServicesInvoice(InvoicesAppDbContext dbContext) { 
        
        _context= dbContext;
        }

      
      
        public BayInvoiceViewModel index()
        {
            try
            {
                var model = new BayInvoiceViewModel()
            {
                Categories =  _context.Categorys.Where(p => p.CurrentState == 1).ToList(),
                Suppliers = _context.Suppliers.Where(p => p.CurrentState == 1).ToList()
            };
           return model;

        }
            catch (Exception) { return null; }

}

        public  bool Invoices(BayInvoiceViewModel model)
        {
            try
            {
                var invoice = new Invoice();
                invoice.BranchId = 1;
                invoice.Disconut = model.Invoice.Disconut;
                invoice.SupplierId = model.Invoice.SupplierId;
                invoice.Date = model.Invoice.Date;
                invoice.TotalBeforeDisconut = model.Invoice.TotalBeforeDisconut;
                invoice.TotalAftarDisconut = model.Invoice.TotalAftarDisconut;
                invoice.Total = model.Invoice.TotalAftarDisconut;

                   _context.Invoices.Add(invoice);
                 _context.SaveChanges();
                var Invoices = _context.Invoices.Where(i => i.BranchId == 1 && i.Date == model.Invoice.Date).FirstOrDefault();
                var invoicetemp = _context.InvoiceTemp.ToList();
                var invoiceItems = invoicetemp.Select(item => new InvoiceItem
                {
                    InvoiceId = invoice.Id,
                    CategoryId = item.CategoryId,
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Total = item.Total,
                    Quantity = item.Quantity
                }).ToList();

                _context.InvoiceItem.AddRange(invoiceItems);
                _context.InvoiceTemp.RemoveRange(invoicetemp);
                 _context.SaveChanges();
                return true;

            }
            catch (Exception) { return false; }
        }
    }
}
