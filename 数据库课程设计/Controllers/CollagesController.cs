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
    public class CollagesController : Controller
    {
        private readonly SchoolContext _context;

        public CollagesController(SchoolContext context)
        {
            _context = context;    
        }

        // GET: Collages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Collage.ToListAsync());
        }

        // GET: Collages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collage = await _context.Collage
                .SingleOrDefaultAsync(m => m.Id == id);
            if (collage == null)
            {
                return NotFound();
            }

            return View(collage);
        }

        // GET: Collages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Collages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Collage collage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(collage);
        }

        // GET: Collages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collage = await _context.Collage.SingleOrDefaultAsync(m => m.Id == id);
            if (collage == null)
            {
                return NotFound();
            }
            return View(collage);
        }

        // POST: Collages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Collage collage)
        {
            if (id != collage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollageExists(collage.Id))
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
            return View(collage);
        }

        // GET: Collages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collage = await _context.Collage
                .SingleOrDefaultAsync(m => m.Id == id);
            if (collage == null)
            {
                return NotFound();
            }

            return View(collage);
        }

        // POST: Collages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collage = await _context.Collage.SingleOrDefaultAsync(m => m.Id == id);
            _context.Collage.Remove(collage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CollageExists(int id)
        {
            return _context.Collage.Any(e => e.Id == id);
        }
    }
}
