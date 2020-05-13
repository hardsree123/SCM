using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            var requirements = _seeker.GetOverallStatus();
            return View(requirements);
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
