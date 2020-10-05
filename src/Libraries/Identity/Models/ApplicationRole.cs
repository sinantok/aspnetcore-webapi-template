using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public DateTime? CreatedDate { get; set; }
    }
}
