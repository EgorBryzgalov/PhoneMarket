﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneMarket.Models;


namespace PhoneMarket.Controllers
{
    public class HomeController : Controller
    {
        PhoneContext phoneContext = new PhoneContext();
        public ActionResult Index()
        {
            IEnumerable<Phone> phones = phoneContext.Phones;

            ViewBag.Phones = phones;

            return View();

        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;

            phoneContext.Purchases.Add(purchase);

            phoneContext.SaveChanges();

            return $"Уважаемый, {purchase.FIO}, с Вами скоро свяжутся!";
        }

        [HttpGet]
        public ActionResult Purchases()
        {
            IEnumerable<Purchase> purchases = phoneContext.Purchases;

            ViewBag.Purchases = purchases;

            return View();
        }




    }
}