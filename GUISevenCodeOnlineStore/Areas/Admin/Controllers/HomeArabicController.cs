using Microsoft.AspNetCore.Mvc;

namespace GUISevenCodeOnlineStore.Controllers
{
    [Area("Admin")]
    public class HomeArabicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      
    }
}
