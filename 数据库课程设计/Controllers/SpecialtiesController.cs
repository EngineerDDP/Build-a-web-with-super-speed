using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly SchoolContext _context;

        public SpecialtiesController(SchoolContext context)
        {
            _context = context;    
        }

        // GET: Specialties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specialty.ToListAsync());
        }

        // GET: Specialties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Specialty
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        // GET: Specialties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialty);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(specialty);
        }

        // GET: Specialties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Specialty.SingleOrDefaultAsync(m => m.Id == id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        // POST: Specialties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Specialty specialty)
        {
            if (id != specialty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialtyExists(specialty.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(specialty);
        }

        // GET: Specialties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _context.Specialty
                .SingleOrDefaultAsync(m => m.Id == id);
            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        // POST: Specialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialty = await _context.Specialty.SingleOrDefaultAsync(m => m.Id == id);
            _context.Specialty.Remove(specialty);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SpecialtyExists(int id)
        {
            return _context.Specialty.Any(e => e.Id == id);
        }
    }
}
