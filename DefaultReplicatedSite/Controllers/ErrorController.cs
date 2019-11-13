using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultReplicatedSite.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult InvalidWebalias()
        {
            return View();
        }
    }
}