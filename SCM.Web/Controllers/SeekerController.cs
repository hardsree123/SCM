using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCM.Business.Provider;
using SCM.Model;

namespace SCM.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeekerController : ControllerBase
    {
        private readonly ISeekerProvider _seekerProvider;
        public SeekerController(ISeekerProvider seeker)
        {
            _seekerProvider = seeker;
        }


        // GET: api/Covids
        [HttpGet]
        public async Task<IEnumerable<SeekerLocation>> GetSeekerLocations()
        {
            return await _seekerProvider.GetSeekerLocations();
        }
    }
}