using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entity
{
    public class RelBranch
    {
        public int BranchId { get; set; }

        public Branch? Branch { get; set; }
    }
}
