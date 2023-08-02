﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Adderess { get; set; }

        public int CurrentState { get; set; } = 1;
        public string? CreateUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdateUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? DeleteUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
