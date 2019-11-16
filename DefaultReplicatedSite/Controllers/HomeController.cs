﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultReplicatedSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Identity.Owner != null)
            {
                var CustomerID = Identity.Owner.CustomerId;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.LeftMenu = true;
            ViewBag.LeftMenuTitle = "MEMBERSHIP LEVELS";
            ViewBag.LefMenuExclude = 0;
            ViewBag.HeaderImg = "../../Content/images/shutterstock_1132149689-b.jpg?resize=2400%2C1800&ssl=1";
            ViewBag.Title = "WHO IS LUXXIUM";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MemberLevel()
        {
            ViewBag.LeftMenu = true;
            ViewBag.LeftMenuTitle = "ADDITIONAL MEMBERSHIP LEVELS";
            ViewBag.LefMenuExclude = 1;
            ViewBag.HeaderImg = "../../Content/images/shutterstock_245480017.jpg?resize=2400%2C1800&ssl=1";
            ViewBag.Title = "R + R CLUB MEMBER";
            return View("~/Views/Opportunity/RRClubMember.cshtml");
        }
        public ActionResult InfluencerLevel()
        {
            ViewBag.LeftMenu = true;
            ViewBag.LeftMenuTitle = "ADDITIONAL MEMBERSHIP LEVELS";
            ViewBag.LefMenuExclude = 2;
            ViewBag.HeaderImg = "../../Content/images/shutterstock_245479945.jpg?resize=2400%2C1800&ssl=1";
            ViewBag.Title = "INFLUENCER LEVEL";
            return View("~/Views/Opportunity/InfluencerLevel.cshtml");
        }
        public ActionResult RetailerLevel()
        {
            ViewBag.LeftMenu = true;
            ViewBag.LeftMenuTitle = "ADDITIONAL MEMBERSHIP LEVELS";
            ViewBag.LefMenuExclude = 3;
            ViewBag.HeaderImg = "../../Content/images/shutterstock_320026151.jpg?resize=2400%2C1800&ssl=1";
            ViewBag.Title = "RETAILER LEVEL";
            return View("~/Views/Opportunity/RetailerLevel.cshtml");
        }

        public ActionResult CompensationPlan()
        {
            ViewBag.LeftMenu = true;
            ViewBag.LeftMenuTitle = "MEMBERSHIP LEVELS";
            ViewBag.LefMenuExclude = 0;
            ViewBag.HeaderImg = "../../Content/images/shutterstock_678404389.jpg?resize=2400%2C1800&ssl=1";
            ViewBag.Title = "COMPENSATION PLAN";
            return View("~/Views/Opportunity/CompensationPlan.cshtml");
        }

        public ActionResult WhatIsRR()
        {
            ViewBag.LeftMenu = true;
            ViewBag.LeftMenuTitle = "MEMBERSHIP LEVELS";
            ViewBag.LefMenuExclude = 3;
            ViewBag.HeaderImg = "../../Content/images/shutterstock_735691957.jpg?resize=2400%2C1800&ssl=1";
            ViewBag.Title = "R + R PROGRAM";
            return View("~/Views/Opportunity/WhatIsRR.cshtml");
        }

        public ActionResult WhoWeAre()
        {
            ViewBag.LeftMenu = true;
            ViewBag.LeftMenuTitle = "MEMBERSHIP LEVELS";
            ViewBag.LefMenuExclude = 3;
            ViewBag.HeaderImg = "../../Content/images/shutterstock_735691957.jpg?resize=2400%2C1800&ssl=1";
            ViewBag.Title = "Who Is Luxxium";
            return View("~/Views/Home/WhoWeAre.cshtml");
        }
        public ActionResult HowToLuxxium()
        {
            ViewBag.LeftMenu = true;
            ViewBag.LeftMenuTitle = "MEMBERSHIP LEVELS";
            ViewBag.LefMenuExclude = 3;
            ViewBag.HeaderImg = "../../Content/images/shutterstock_735691957.jpg?resize=2400%2C1800&ssl=1";
            ViewBag.Title = "How To Luxxium";
            return View("~/Views/Home/HowToLuxxium.cshtml");
        }
        public ActionResult Testimonials()
        {
            ViewBag.LeftMenu = true;
            ViewBag.LeftMenuTitle = "MEMBERSHIP LEVELS";
            ViewBag.LefMenuExclude = 3;
            ViewBag.HeaderImg = "../../Content/images/shutterstock_735691957.jpg?resize=2400%2C1800&ssl=1";
            ViewBag.Title = "Testimonials";
            return View("~/Views/Home/Testimonials.cshtml");
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult Membership()
        {
            return View();
        }
        public ActionResult Policies()
        {
            return View();
        }
        public ActionResult Returns()
        {
            return View();
        }
        public ActionResult TermsOfUse()
        {
            return View();
        }
    }
}