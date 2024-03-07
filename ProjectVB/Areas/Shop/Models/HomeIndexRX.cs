using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVB.Areas.Shop.Models
{
    public class HomeIndexRX
    {
        public List<Model.Entities.Category> CategoryList { get; set; }

        public List<Model.Entities.Product> ProductList { get; set; }
    }
}
