using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Supplier : BaseEntity
    {
        [Key]
        public int id { get; set; } 
        public string name { get; set; }
        = string.Empty;

    }
}
