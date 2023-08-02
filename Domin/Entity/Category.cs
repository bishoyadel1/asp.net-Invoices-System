using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Category : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string  CategoryName{ get; set; } =string.Empty;


    }
}
