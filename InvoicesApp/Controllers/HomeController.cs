using Domin.Entity;
using Domin.ViewModel;
using Infrastructure.Data;
using Infrastructure.IRepository;
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
        private readonly IServicesInvoice<BayInvoiceViewModel> _servicesInvoice;
        private readonly IServicesProduct<Product> _servicesProduct;
        public HomeController(ILogger<HomeController> logger, InvoicesAppDbContext context ,IServicesInvoice<BayInvoiceViewModel> servicesInvoice, IServicesProduct<Product> servicesProduct)
        {
            _logger = logger;
            _context = context;
            _servicesInvoice = servicesInvoice;
            _servicesProduct = servicesProduct;
        }

        public IActionResult Index()  =>  View(_servicesInvoice.index());
     
        public IActionResult GetProduct(string Id) => Json(_servicesProduct.GetProduct(Id));
      
        public IActionResult GetProductPrice(string Id) => Json(_servicesProduct.GetProductPrice(Id));
        

        public async Task<IActionResult> Invoices(BayInvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {      
             if (_servicesInvoice.Invoices(model))
                return RedirectToAction("Index","Home");
             else
                    return BadRequest();
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