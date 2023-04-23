using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb1EntityFrameWork.Data;
using Labb1EntityFrameWork.Models;

namespace Labb1EntityFrameWork.Controllers
{
    public class VacationListsController : Controller
    {
        private readonly VacationContext _context;

        public VacationListsController(VacationContext context)
        {
            _context = context;
        }

        // GET: VacationLists
        public async Task<IActionResult> Index()
        {
            var vacationContext = _context.VacationLists.Include(v => v.Employees).Include(v => v.Vacations);
            return View(await vacationContext.ToListAsync());
        }

		// GET: Vacations/VacationSearch
		public async Task<IActionResult> VacationSearch()
		{
			var vacationContext = _context.VacationLists.Include(v => v.Employees);
			return View(await vacationContext.ToListAsync());
		}

		// Post: Vacations/ShowSearchResults
		public async Task<IActionResult> ShowSearchResults(string VacationSearch)
		{
			var vacationContext = _context.VacationLists.Include(v => v.Employees);
			return View("Index", await vacationContext.Where(v => v.Employees.LastName.Contains(VacationSearch)).ToListAsync());
		}

		// GET: Vacations/Admin
		public async Task<IActionResult> Admin()
		{
			var vacationContext = _context.VacationLists.Include(v => v.Employees);
			return View(await vacationContext.ToListAsync());
		}

		// Post: Vacations/AdminShowResults
		public async Task<IActionResult> AdminShowResults(DateTime SearchStart, DateTime SearchEnd)
		{
			var vacationContext = _context.VacationLists.Include(v => v.Employees);
			return View("Index", await vacationContext.Where(v => v.DateApplied > SearchStart && v.DateApplied < SearchEnd).ToListAsync());
		}

		// GET: VacationLists/Details/5
		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VacationLists == null)
            {
                return NotFound();
            }

            var vacationList = await _context.VacationLists
                .Include(v => v.Employees)
                .Include(v => v.Vacations)
                .FirstOrDefaultAsync(m => m.VacationListId == id);
            if (vacationList == null)
            {
                return NotFound();
            }

            return View(vacationList);
        }

        // GET: VacationLists/Create
        public IActionResult Create()
        {
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            ViewData["FK_VacationId"] = new SelectList(_context.Vacations, "VacationId", "VacayType");
            return View();
        }

        // POST: VacationLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacationListId,StartDate,EndDate,DateApplied,FK_EmployeeId,FK_VacationId")] VacationList vacationList)
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();

            if (ModelState.IsValid)
            {
                _context.Add(vacationList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", vacationList.FK_EmployeeId);
            ViewData["FK_VacationId"] = new SelectList(_context.Vacations, "VacationId", "VacayType", vacationList.FK_VacationId);
            return View(vacationList);
        }

        // GET: VacationLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VacationLists == null)
            {
                return NotFound();
            }

            var vacationList = await _context.VacationLists.FindAsync(id);
            if (vacationList == null)
            {
                return NotFound();
            }
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", vacationList.FK_EmployeeId);
            ViewData["FK_VacationId"] = new SelectList(_context.Vacations, "VacationId", "VacayType", vacationList.FK_VacationId);
            return View(vacationList);
        }

        // POST: VacationLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacationListId,StartDate,EndDate,DateApplied,FK_EmployeeId,FK_VacationId")] VacationList vacationList)
        {
            if (id != vacationList.VacationListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacationList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationListExists(vacationList.VacationListId))
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
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", vacationList.FK_EmployeeId);
            ViewData["FK_VacationId"] = new SelectList(_context.Vacations, "VacationId", "VacayType", vacationList.FK_VacationId);
            return View(vacationList);
        }

        // GET: VacationLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VacationLists == null)
            {
                return NotFound();
            }

            var vacationList = await _context.VacationLists
                .Include(v => v.Employees)
                .Include(v => v.Vacations)
                .FirstOrDefaultAsync(m => m.VacationListId == id);
            if (vacationList == null)
            {
                return NotFound();
            }

            return View(vacationList);
        }

        // POST: VacationLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VacationLists == null)
            {
                return Problem("Entity set 'VacationContext.VacationLists'  is null.");
            }
            var vacationList = await _context.VacationLists.FindAsync(id);
            if (vacationList != null)
            {
                _context.VacationLists.Remove(vacationList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationListExists(int id)
        {
          return (_context.VacationLists?.Any(e => e.VacationListId == id)).GetValueOrDefault();
        }
    }
}
