using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SzycieNaMiare.Data;
using SzycieNaMiare.Models;

namespace SzycieNaMiare.Controllers
{
    public class GarmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GarmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GarmentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GarmentType.ToListAsync());
        }

        // GET: GarmentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garmentType = await _context.GarmentType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garmentType == null)
            {
                return NotFound();
            }

            return View(garmentType);
        }

        // GET: GarmentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GarmentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Garment garmentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garmentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garmentType);
        }

        // GET: GarmentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garmentType = await _context.GarmentType.FindAsync(id);
            if (garmentType == null)
            {
                return NotFound();
            }
            return View(garmentType);
        }

        // POST: GarmentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Garment garmentType)
        {
            if (id != garmentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garmentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarmentTypeExists(garmentType.Id))
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
            return View(garmentType);
        }

        // GET: GarmentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garmentType = await _context.GarmentType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garmentType == null)
            {
                return NotFound();
            }

            return View(garmentType);
        }

        // POST: GarmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garmentType = await _context.GarmentType.FindAsync(id);
            if (garmentType != null)
            {
                _context.GarmentType.Remove(garmentType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarmentTypeExists(int id)
        {
            return _context.GarmentType.Any(e => e.Id == id);
        }
    }
}
