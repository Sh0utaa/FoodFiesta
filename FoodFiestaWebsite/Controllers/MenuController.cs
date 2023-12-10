using Microsoft.AspNetCore.Mvc;

namespace FoodFiestaWebsite.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Food()
        {
            return View();
        }
        public IActionResult Drinks()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
