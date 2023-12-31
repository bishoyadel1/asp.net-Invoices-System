﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Product : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
