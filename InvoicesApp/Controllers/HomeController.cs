using Domin.Entity;
using Domin.ViewModel;
using Infrastructure.Data;
using InvoicesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InvoicesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InvoicesAppDbContext _context;
        public HomeController(ILogger<HomeController> logger, InvoicesAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var model = new BayInvoiceViewModel()
            {
                Categories = _context.Categorys.Where(p => p.CurrentState == 1).ToList(),
                Suppliers = _context.Suppliers.Where(p => p.CurrentState == 1).ToList()
            };

            return View(model);
        }
        public IActionResult GetProduct(string Id)
        {

            var Product = _context.Products.Where(p => p.CurrentState == 1 && p.CategoryId.Equals(int.Parse(Id))).ToList();
            return Json(Product);
        }
        public IActionResult GetProductPrice(string Id)
        {
            return Json(_context.Products.Where(p => p.Id.Equals(int.Parse(Id))).First());
        }


        public async Task<IActionResult> Invoices(BayInvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var invoice = new Invoice();
                invoice.BranchId = 1;
                invoice.Disconut = model.Invoice.Disconut;
                invoice.SupplierId = model.Invoice.SupplierId;
                invoice.Date = model.Invoice.Date;
                invoice.TotalBeforeDisconut = model.Invoice.TotalBeforeDisconut;
                invoice.TotalAftarDisconut = model.Invoice.TotalAftarDisconut;
                invoice.Total = model.Invoice.TotalAftarDisconut;

                await _context.Invoices.AddAsync(invoice);
                await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return BadRequest();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}