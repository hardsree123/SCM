using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCM.Business.DbModel;

namespace SCM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementsController : ControllerBase
    {
        private readonly MySqlContext _context;

        public RequirementsController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Requirements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requirements>>> GetRequirements()
        {
            return await _context.Requirements.ToListAsync();
        }

        // GET: api/Requirements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requirements>> GetRequirements(uint id)
        {
            var requirements = await _context.Requirements.FindAsync(id);

            if (requirements == null)
            {
                return NotFound();
            }

            return requirements;
        }

        // PUT: api/Requirements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequirements(uint id, Requirements requirements)
        {
            if (id != requirements.Id)
            {
                return BadRequest();
            }

            _context.Entry(requirements).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequirementsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Requirements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Requirements>> PostRequirements(Requirements requirements)
        {
            _context.Requirements.Add(requirements);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequirements", new { id = requirements.Id }, requirements);
        }

        // DELETE: api/Requirements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Requirements>> DeleteRequirements(uint id)
        {
            var requirements = await _context.Requirements.FindAsync(id);
            if (requirements == null)
            {
                return NotFound();
            }

            _context.Requirements.Remove(requirements);
            await _context.SaveChangesAsync();

            return requirements;
        }

        private bool RequirementsExists(uint id)
        {
            return _context.Requirements.Any(e => e.Id == id);
        }
    }
}
