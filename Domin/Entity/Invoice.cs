using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Invoice : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public DateTime Date { get; set; }
        public decimal TotalBeforeDisconut { get; set; }
        public decimal Disconut { get; set; }
        public decimal TotalAftarDisconut { get; set; }
        public decimal? Total { get; set; }

        public List<InvoiceItem>? InvoiceItems { get; set; }
    }
}
