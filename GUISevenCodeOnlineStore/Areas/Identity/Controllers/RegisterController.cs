using DALSevenCodeOnlineStore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GUISevenCodeOnlineStore.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            
            return View();
        }

        public async Task<IActionResult> RegisterNewUser([Bind("Email,PasswordHash")] ApplicationUser aspNetUsers, string returnUrl = null)
        {
            try
            {
                //http://localhost:63671/Admin/home/Index
                returnUrl = returnUrl ?? Url.Content("~/Customer/Home/Index");

                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = aspNetUsers.Email, Email = aspNetUsers.Email, EmailConfirmed = true, UserType = 2 };
                    var result = await _userManager.CreateAsync(user, aspNetUsers.PasswordHash);
                    if (result.Succeeded)
                    {
                        aspNetUsers.Id = user.Id.ToString(); //return LocalRedirect(returnUrl);
                        //ViewBag.RegisterNewUser = "New User has created success.";
                    }

                   // return LocalRedirect(returnUrl);
                }

                return LocalRedirect(returnUrl);
            }
           
            catch 
            {
                return LocalRedirect(returnUrl);
            }
        }



    }
}
