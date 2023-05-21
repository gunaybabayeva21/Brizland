using BrizLand.DataContext;
using BrizLand.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrizLand.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class ServisController : Controller
    {

        private readonly BrizLandDbContext _brizLandDbContext;
        public ServisController(BrizLandDbContext brizLandDbContext)
        {
            _brizLandDbContext = brizLandDbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            Servis? servic = await _brizLandDbContext.services.FindAsync(id);
            {
                if (servic == null)
                {
                    return NotFound();
                }
                return View(servic);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            Servis? servis = _brizLandDbContext.services.FirstOrDefaultAsync(x => x.Id == id);
            if (servis == null) return NotFound();

            _brizLandDbContext = servis.Remove(servis);
            _brizLandDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Create (Servis servis)
        {
            if(!ModelState.IsValid) return View(servis);
            if (_brizLandDbContext.services.Any(c => c.Title.Trim().ToLower() == servis.Title.Trim().ToLower()))
            {
                ModelState.AddModelError("Title", "Alreade exist");
            }
            await _brizLandDbContext.services.AddAsync(servis);
            await _brizLandDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        

        public IActionResult Update(int id) 
        {
            Servis? servis = _brizLandDbContext.services.FirstOrDefault(s => s.Id == id);
            if(servis == null) return NotFound();
            return View(servis);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

         public IActionResult Update (int id, Servis newservis)
         {
            Servis? services=_brizLandDbContext.services.FirstOrDefault(s=>s.Id == id);
            if(services == null) return NotFound();
            if (_brizLandDbContext.services.Any(c => c.Title.Trim().ToLower() == newservis.Title.Trim().ToLower()))
            {
                ModelState.AddModelError("Title", "Alreade exist");
            }
            services.Title = newservis.Title;
            services.Description = newservis.Description;

            _brizLandDbContext.SaveChanges();
            return RedirectToAction("Index");
         }
           

    }
}


