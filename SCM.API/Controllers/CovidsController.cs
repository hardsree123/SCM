using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCM.Business.DbModel;
using SCM.Business.Provider;

namespace SCMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidsController : ControllerBase
    {
        private readonly ICovidProvider _covideContext;

        private static readonly string[] Countries = new[]
        {
            "India", "Brazil", "Euthopia", "Canada", "USA", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public CovidsController(ICovidProvider context)
        {
            _covideContext = context;
        }

        // GET: api/Covids
        [HttpGet]
        public async Task<IEnumerable<Covid>> GetCovid()
        {
            return await _covideContext.GetCovid();
        }
        
        [HttpGet]
        [Route("Fetch")]
        public IEnumerable<Covid> Fetch()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Covid
            {
                Date = DateTime.Now.AddDays(index),
                Lat = rng.Next(-20, 55),
                Long = rng.Next(-20, 55),
                Country = Countries[rng.Next(Countries.Length)],
            })
            .ToArray();
        }

        // GET: api/Covids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Covid>> GetCovid(uint id)
        {
            var covid = await _covideContext.GetCovid(id);

            if (covid == null)
            {
                return NotFound();
            }

            return covid;
        }

        // PUT: api/Covids/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCovid(uint id, Covid covid)
        {
            int res = await _covideContext.PutCovid(id, covid);
            if (res.Equals(-2))
            {
                return BadRequest();
            }
            else if (res.Equals(-1))
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Covids
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Covid>> PostCovid(Covid covid)
        {
           
            await _covideContext.PostCovid(covid);

            return CreatedAtAction("GetCovid", new { id = covid.ForecastId }, covid);
        }

        // DELETE: api/Covids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Covid>> DeleteCovid(uint id)
        {
            var covid = await _covideContext.DeleteCovid(id);
            if (covid == null)
            {
                return NotFound();
            }

            return covid;
        }

    }
}
