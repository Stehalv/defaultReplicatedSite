using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Controllers
{
    public class CheckoutController : Controller
    {
        public ActionResult Index()
        {
            var model = new CheckoutViewModel();
            if(Identity.Customer != null)
            {
                
            }
            model.CheckoutStep = CheckoutSteps.Information;
            return View(model);
        }
    }
}