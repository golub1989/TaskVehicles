using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleProject.Context;
using VehicleProject.Models;

namespace VehicleProject.Controllers
{
    public class VehicleMakesController : Controller
    {
        private readonly MVCContext db;

        public VehicleMakesController(MVCContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(VehicleMake vehicle)
        {
            if(!ModelState.IsValid) return View(vehicle);

            db.Vehicles.Add(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await db.Vehicles
                .Include(v => v.VehicleModels)
                .FirstOrDefaultAsync(m => m.VehicleMakeID == id);
            if (vehicle == null)
            {
                return NotFound();
            }


            return View(vehicle);
        }
        
    }
}
