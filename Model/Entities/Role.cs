
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        public virtual ICollection<AdminRole> AdminRoles { get; set; }
    }
}