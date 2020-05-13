using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCM.Business.DbModel;
using SCM.Model;

namespace SCM.Web.Controllers
{
    public class RequirementsController : Controller
    {
        private readonly MySqlContext _context;

        public RequirementsController(MySqlContext context)
        {
            _context = context;
        }

        // GET: Requirements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Requirements.ToListAsync());
        }

        // GET: Requirements/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirements = await _context.Requirements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requirements == null)
            {
                return NotFound();
            }

            return PartialView(requirements);
        }

        // GET: Requirements/Create
        public IActionResult Create()
        {
            ViewBag.PriorityList = Common.GetPriority();
            return View();
        }

        // POST: Requirements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequirerName,Age,RequirementDesc,VolunteerCode,Address,ContactNo,RequestedDate,RequestDueDate,RequestCompleted,RequestCancelled,CancellationDesc,Priority,StatusOfRequest,Lat,Long,AdditionalDetails")] Requirements requirements)
        {
            if (ModelState.IsValid)
            {
                requirements.StatusOfRequest = 101003;//default due status is inserted
                _context.Add(requirements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requirements);
        }

        // GET: Requirements/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirements = await _context.Requirements.FindAsync(id);
            ViewBag.PriorityList = Common.GetPriority();
            ViewBag.StatusList = Common.GetStatus();

            if (requirements == null)
            {
                return NotFound();
            }
            return View(requirements);
        }

        // POST: Requirements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,RequirerName,Age,RequirementDesc,VolunteerCode,Address,ContactNo,RequestedDate,RequestDueDate,RequestCompleted,RequestCancelled,CancellationDesc,Priority,StatusOfRequest,Lat,Long,AdditionalDetails")] Requirements requirements)
        {
            if (id != requirements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (requirements.StatusOfRequest.Value.Equals((int)RequestStatus.Cancelled))
                    {
                        requirements.RequestCancelled = DateTime.Now;
                    }
                    else if(requirements.StatusOfRequest.Value.Equals((int)RequestStatus.Delivered))
                    {
                        requirements.RequestCompleted = DateTime.Now;
                    }
                    _context.Update(requirements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequirementsExists(requirements.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(requirements);
        }

        // GET: Requirements/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirements = await _context.Requirements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requirements == null)
            {
                return NotFound();
            }

            return View(requirements);
        }

        // POST: Requirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var requirements = await _context.Requirements.FindAsync(id);
            _context.Requirements.Remove(requirements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequirementsExists(uint id)
        {
            return _context.Requirements.Any(e => e.Id == id);
        }
    }
}
