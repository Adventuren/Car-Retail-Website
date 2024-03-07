using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVB.Areas.Admin.Models
{
    public class NewAdmin
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public bool IsActive { get; set; }
        public int[] RoleIds { get; set; }
    }
}
