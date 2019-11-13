using DefaultReplicatedSite.Services;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultReplicatedSite.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var response = new IdentityService().SignIn(model.UserName, model.Password);
            return new JsonNetResult(new
            {
                success = true
            });
        }
    }
}