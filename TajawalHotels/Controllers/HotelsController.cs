using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TajawalHotels.BL;
using TajawalHotels.Models;

namespace TajawalHotels.Controllers
{
    public class HotelsController : ApiController
    {

        public static List<Hotel> data = new List<Hotel>(); 

        [HttpGet]
        [ActionName("GetAllHotels")]

        public IEnumerable<Hotel> GetAllHotels()
        {
            try
            {
                var hotelbuisness = new HotelBusiness();
                var hotels = hotelbuisness.GetHotels();
                if (hotels != null)
                {
                    
                    data = hotels.Hotels;
                    return data;
                }
                return new List<Hotel>();

            }
            catch (Exception)
            {

                return new List<Hotel>();
            }
        
        }


        [HttpPost]
        [ActionName("GetFilteredHotels")]

        public IEnumerable<Hotel> GetFilteredHotels(SearchModel model)
        {
            var filteredData = new List<Hotel>();
            filteredData = data;
            try
            {
                if (!string.IsNullOrEmpty(model.Name))
                {
                    filteredData = filteredData.Where(e => e.Name.ToLower().Contains(model.Name.ToLower())).ToList();

                }

                if (!string.IsNullOrEmpty(model.City))
                {
                    filteredData = filteredData.Where(e => e.City.ToLower().Contains(model.City.ToLower())).ToList();

                }

                if (model.PriceFrom.HasValue)
                {
                    filteredData = filteredData.Where(e => e.Price >= model.PriceFrom).ToList();

                }
                if (model.PriceTo.HasValue)
                {
                    filteredData = filteredData.Where(e => e.Price <= model.PriceTo).ToList();

                }

                if (model.DateFrom.HasValue)
                {
                    filteredData = filteredData.Where(e => e.Availability.Any(x => x.From.Date >= model.DateFrom.Value.Date)).ToList();

                }
                if (model.DateTo.HasValue)
                {
                    filteredData = filteredData.Where(e => e.Availability.Any(x => x.From.Date <= model.DateTo.Value.Date)).ToList();

                }

                return filteredData;
            }
            catch (Exception)
            {

                return new List<Hotel>();
            }
         
        
        }
        // GET: api/Hotels/5

    }
}
