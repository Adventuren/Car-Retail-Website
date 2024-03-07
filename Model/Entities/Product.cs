using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Product : BaseEntity
    {

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
        public string PhotoPath { get; set; }

        

        
    }
}
