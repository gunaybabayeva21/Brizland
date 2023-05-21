using Microsoft.AspNetCore.Mvc;

namespace BrizLand.Areas.Admin.Controllers
{
    public class DashBoardController:Controller
    {
        [Area("Admin")]
        public IActionResult Index()

        {
            return View();
        }

    }
}
