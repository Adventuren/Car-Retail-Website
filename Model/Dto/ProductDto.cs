using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Dto
{
   public class ProductDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Marka { get; set; }
        public string Seri { get; set; }
        public int Yil { get; set; }
        public decimal Fiyat { get; set; }
        public string AracDurumu { get; set; }
        public string Yakit { get; set; }
        public double KM { get; set; }
        public string Renk { get; set; }
        public string Vites { get; set; }
        public int CategoryId { get; set; }
    }
}
