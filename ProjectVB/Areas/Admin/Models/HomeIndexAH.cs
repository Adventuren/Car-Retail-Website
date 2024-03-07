using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVB.Areas.Admin.Models
{
    public class HomeIndexAH
    {
        public List<Model.Entities.Admin> AdminList { get; set; }

        public List<Role> RoleList { get; set; }
    }
}
