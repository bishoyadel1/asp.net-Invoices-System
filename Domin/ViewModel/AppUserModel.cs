
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.ViewModel
{
    public  class AppUserModel : IdentityUser
    {
        public string Name { get; set;}
      
        public bool ActiveUser { get; set; }

        public Guid ImagesUserId { get; set; }
      //  public List<ImagesUser> Image { get; set; }
    }
}
