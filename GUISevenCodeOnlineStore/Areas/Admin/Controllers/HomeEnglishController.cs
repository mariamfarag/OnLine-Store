using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GUISevenCodeOnlineStore.Controllers
{
    [Area("Admin")]
   // [Route("Admin")]
    public class HomeEnglishController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

    }
}
