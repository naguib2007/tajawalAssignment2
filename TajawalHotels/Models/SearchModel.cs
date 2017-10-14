using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TajawalHotels.Models
{
    public class SearchModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public DateTime ? DateFrom { get; set; }
        public DateTime ? DateTo { get; set; }
    }
}