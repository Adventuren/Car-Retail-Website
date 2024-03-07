using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto
{
   public class AdminDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}

