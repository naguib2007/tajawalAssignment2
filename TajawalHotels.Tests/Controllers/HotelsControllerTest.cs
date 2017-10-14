﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TajawalHotels.Controllers;
using TajawalHotels.Models;
using System.Collections.Generic;
using TajawalHotels.BL;

namespace TajawalHotels.Tests.Controllers
{
    [TestClass]
    public class HotelsControllerTest
    {
        [TestMethod]
        public void GetHotels_ReturnAll()
        {
          var TestedHotels=  GetTestHotels();
            var controller = new HotelsController();

            var result = controller.GetAllHotels() as List<Hotel>;
            Assert.AreEqual(TestedHotels.Count, result.Count);
        }

        [TestMethod]
        public void GetHotels_FilterationName()
        {
           // var TestedHotels = GetTestHotels();
            var controller = new HotelsController();
            var searchModel = new SearchModel
            {
                Name = "Rotana Hotel"

            };

            var result = controller.GetFilteredHotels(searchModel) as List<Hotel>;
            Assert.AreEqual(1, result.Count);
        }
        [TestMethod]
        public void GetHotels_FilterationCity()
        {
           // var TestedHotels = GetTestHotels();
            var controller = new HotelsController();
            var searchModel = new SearchModel
            {
                City = "Manila"

            };

            var result = controller.GetFilteredHotels(searchModel) as List<Hotel>;
            Assert.AreEqual(1, result.Count);
        }
        [TestMethod]
        public void GetHotels_FilterationFromPrice()
        {
          //  var TestedHotels = GetTestHotels();
            var controller = new HotelsController();
            var searchModel = new SearchModel
            {
                PriceFrom = 111

            };

            var result = controller.GetFilteredHotels(searchModel) as List<Hotel>;
            Assert.AreEqual(1, result.Count);
        }
        [TestMethod]
        public void GetHotels_FilterationtoPrice()
        {
            var TestedHotels = GetTestHotels();
            var controller = new HotelsController();
            var searchModel = new SearchModel
            {
                PriceTo = 1000000000000000

            };

            var result = controller.GetFilteredHotels(searchModel) as List<Hotel>;
            Assert.AreEqual(TestedHotels.Count, result.Count);
        }

        [TestMethod]
        public void GetHotels_FilterationFromdate()
        {
             var TestedHotels = GetTestHotels();
            var controller = new HotelsController();
            var searchModel = new SearchModel
            {
                DateFrom = DateTime.Now

            };

            var result = controller.GetFilteredHotels(searchModel) as List<Hotel>;
            Assert.AreEqual(TestedHotels.Count, result.Count);
        }
        [TestMethod]
        public void GetHotels_FilterationtoDate()
        {
            var TestedHotels = GetTestHotels();
            var controller = new HotelsController();
            var searchModel = new SearchModel
            {
                DateTo =DateTime.MaxValue

            };

            var result = controller.GetFilteredHotels(searchModel) as List<Hotel>;
            Assert.AreEqual(TestedHotels.Count, result.Count);
        }

        private List<Hotel> GetTestHotels()
        {
            var hotelbuisness = new HotelBusiness();
            var hotels = hotelbuisness.GetHotels();
            if (hotels != null)
            {

              var  data = hotels.Hotels;
                return data;
            }
            return new List<Hotel>();
        }
    }
}
