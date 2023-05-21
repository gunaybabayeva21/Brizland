using BrizLand.DataContext;
using BrizLand.Models;
using BrizLand.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BrizLand.Controllers
{
    public class HomeController : Controller
    {
        private readonly BrizLandDbContext _brizLandDbContext;
        public HomeController (BrizLandDbContext brizLandDbContext)
        {
            _brizLandDbContext = brizLandDbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<Servis> Services = await _brizLandDbContext.services.ToListAsync();
            HomeVM homeVM = new HomeVM()
            {
                services = Services
            };
            return View(homeVM);
        }



    }
}