using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class AdminRole : BaseEntity
    {
        public int? AdminId { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
