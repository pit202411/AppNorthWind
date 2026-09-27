using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppNorthWind.Models
{
    public class SellingOrderUpdateDto
    {
        public int IdSellingOrder { get; set; }
        public int IdEmployee { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
    }
}