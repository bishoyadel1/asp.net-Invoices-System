using Domin.Entity;
using Infrastructure.Data;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FreeInvoices.APIControllers
{
    [Route("api/Invoice")]
    [ApiController]
    public class APIInvoiceController : ControllerBase
    {
        private readonly InvoicesAppDbContext _context;
        public APIInvoiceController(InvoicesAppDbContext context)
        {
            _context = context;
        }
        // GET: api/<APIInvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.InvoiceTemp.Include(x => x.Category).Include(x => x.Product).ToList());
        }



        // GET api/<APIInvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIInvoiceController>
        [HttpPost]
        public IActionResult Post([FromBody] Domin.Entity.InvoiceTemp value)
        {
            try {
                var product = _context.InvoiceTemp.Where(p=>p.ProductId == value.ProductId && p.CategoryId==value.CategoryId ).FirstOrDefault();
                if(product == null)
                {
                    value.BranchId = 1;
                    _context.InvoiceTemp.Add(value);
               ;
                }
                else
                {
                    product.Total += value.Total;
                    product.Quantity += value.Quantity;
                    _context.InvoiceTemp.Update(product);
                }
                _context.SaveChanges();

                return Ok();

            }
            catch(Exception Ex )
            {
                return BadRequest(Ex);
            }
        }

        // PUT api/<APIInvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIInvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("GetTotal")]
        public IActionResult GetTotal()
        {

            return Ok(_context.InvoiceTemp.Sum(i => i.Total));
        }

        [HttpGet("Discount")]
        public IActionResult Discount()
        {
            var mod = 0;
            var model = _context.InvoiceTemp;
            if (model.Sum(T =>T.Total)<500) { mod = 5; } else { mod = 10; }
            
           var dicount = mod*model.Sum(h=>h.Total)/100;
            return Ok(dicount);
        }
    }
}
