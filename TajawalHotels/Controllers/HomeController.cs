using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TajawalHotels.BL;
using TajawalHotels.Models;

namespace TajawalHotels.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Hotels";
         
            return View();
        }
    }
}
