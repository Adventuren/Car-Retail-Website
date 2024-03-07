using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Dto
{
  public  class AdminInsertDto
    {
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "FullName saglanmalidir.", AllowEmptyStrings = false)]
        [MaxLength(20, ErrorMessage = "20 KARAKTERDEN UZUN OLAMAZ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email saglanmalidir.", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "Email formatinda olmalidir.")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Password saglanmalidir.", AllowEmptyStrings = false)]
        [MinLength(8, ErrorMessage = "En az 8 karakter olmalidir.")]
        public string Password { get; set; }
    }
}

