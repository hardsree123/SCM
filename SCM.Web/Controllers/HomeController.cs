using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCM.Business.DbModel;
using SCM.Business.Provider;
using SCM.Web.Models;

namespace SCM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISeekerProvider _seeker;
        public HomeController(ISeekerProvider seeker)
        {
            _seeker = seeker;
        }
        const string SessionName = "_Name";
        public IActionResult Index()
        {
            if (TempData["Username"] != null)
            {//set the session
                HttpContext.Session.SetString(SessionName, TempData["Username"].ToString());
            }
            ViewBag.Username = HttpContext.Session.GetString(SessionName);
            
            if (!string.IsNullOrEmpty(ViewBag.Username))
            {
                var requirements = _seeker.GetOverallStatus();
                return View(requirements);
            }
            else
            {
                return View("Error");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
