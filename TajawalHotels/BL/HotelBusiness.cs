using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using TajawalHotels.Models;

namespace TajawalHotels.BL
{
    public class HotelBusiness
    {
     
      
        public HotelList GetHotels()
        {


            using (var client = new System.Net.Http.HttpClient())
            {
                // HTTP POST
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(ConfigurationManager.AppSettings["HotelEndPoint"]).Result;
                string res = "";
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    var result = content.ReadAsStringAsync();
                    res = result.Result;
                }
                var format = "dd-MM-yyyy"; // your datetime format
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
                var deserialized = JsonConvert.DeserializeObject<HotelList>(res,dateTimeConverter);
                return deserialized;

            }
        }
    }
}