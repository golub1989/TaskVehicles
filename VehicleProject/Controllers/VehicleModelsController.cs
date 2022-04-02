#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleProject.Context;
using VehicleProject.Models;

namespace VehicleProject.Controllers
{
    public class VehicleModelsController : Controller
    {
        private readonly MVCContext _context;

        public VehicleModelsController(MVCContext context)
        {
            _context = context;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index()
        {
            var mVCContext = _context.Models.Include(v => v.VehicleMakes);
            return View(await mVCContext.ToListAsync());
        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.Models
                .Include(v => v.VehicleMakes)
                .FirstOrDefaultAsync(m => m.VehicleModelID == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public IActionResult Create()
        {
            ViewData["VehicleMakeID"] = new SelectList(_context.Vehicles, "VehicleMakeID", "Abbreviation");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleModelID,ModelName,VehicleMakeID")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleMakeID"] = new SelectList(_context.Vehicles, "VehicleMakeID", "Abbreviation", vehicleModel.VehicleMakeID);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.Models.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }
            ViewData["VehicleMakeID"] = new SelectList(_context.Vehicles, "VehicleMakeID", "Abbreviation", vehicleModel.VehicleMakeID);
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleModelID,ModelName,VehicleMakeID")] VehicleModel vehicleModel)
        {
            if (id != vehicleModel.VehicleModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicleModel.VehicleModelID))
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
            ViewData["VehicleMakeID"] = new SelectList(_context.Vehicles, "VehicleMakeID", "Abbreviation", vehicleModel.VehicleMakeID);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.Models
                .Include(v => v.VehicleMakes)
                .FirstOrDefaultAsync(m => m.VehicleModelID == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModel = await _context.Models.FindAsync(id);
            _context.Models.Remove(vehicleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(int id)
        {
            return _context.Models.Any(e => e.VehicleModelID == id);
        }
    }
}
