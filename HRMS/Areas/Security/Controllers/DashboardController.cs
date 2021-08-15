using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Areas.Security.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Security/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}