using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TajawalHotels.Models
{
    public class Hotel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("availability")]
        public List<Availability> Availability { get; set; }

    }

    public class Availability
    {
        [JsonProperty("from")]
        public DateTime From { get; set; }
        [JsonProperty("to")]
        public DateTime To { get; set; }
    

    }


    public class HotelList
    {

        [JsonProperty("hotels")]
        public List<Hotel> Hotels { get; set; }
    }
}