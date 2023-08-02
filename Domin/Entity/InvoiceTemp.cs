﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class InvoiceTemp : RelBranch
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Total { get; set; }

    }
}
