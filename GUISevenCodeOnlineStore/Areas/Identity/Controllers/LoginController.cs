using DALSevenCodeOnlineStore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GUISevenCodeOnlineStore.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public string ReturnUrl { get; set; }

        public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]//OnPostAsync//loginmethoud
        public async Task<IActionResult> loginmethoud([Bind("Email,PasswordHash")] ApplicationUser aspNetUsers, string returnUrl = null)
        {
            try
            {
                //http://localhost:63671/Admin/home/Index
                returnUrl = returnUrl ?? Url.Content("~/Admin/Home/Index");

                if (ModelState.IsValid)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(aspNetUsers.Email, aspNetUsers.PasswordHash, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        //string currentUserId = User.Identity.
                        //ApplicationUser currentUser = Users.FirstOrDefault(x => x.Id == currentUserId);
                        //ApplicationUser user = HttpContext.GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());

                        var id = _userManager.GetUserId(User); // Get user id:
                        var user = await _userManager.GetUserAsync(User);

                        var uUsertype = _userManager.Users.FirstOrDefault(e => e.Email == aspNetUsers.Email).UserType;

                        if (uUsertype == 1) //if (user != null && user.UserType == 1)
                        {
                            //_logger.LogInformation("User logged in.");
                            return LocalRedirect(returnUrl);
                        }
                        else
                        {
                            var uUserID = _userManager.Users.FirstOrDefault(e => e.Email == aspNetUsers.Email).Id;
                            TempData["uUserID"] = uUserID;

                            returnUrl = Url.Content("~/Customer/Home/Index");
                        //    _logger.LogInformation("User logged in.");
                            return LocalRedirect(returnUrl);
                        }
                     
                    }
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = false });
                    }
                    if (result.IsLockedOut)
                    {
                     //   _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        //                    ModelState.AddModelError(string.Empty, "محاولة تسجيل دخول غير صحيحة. تحقق من اسم المستخدم وكلمة المرور ");//Invalid login attempt.check Username and password
                    //    ModelState.AddModelError("UserPassInvalid", _localizer["invalidLogin"]);//Invalid login attempt.check Username and password

                        return View("index", aspNetUsers);
                        //return Redirect("~/ar/Login/Index");
                    }
                }

                // If we got this far, something failed, redisplay form
                return View();
            }
            catch (Exception ex)
            {
               // _logger.LogError("Error loginmethoud " + ex.Message.ToString());
                return View();
            }

        }

        public async Task<IActionResult> LogoutMethoud(string returnUrl = null)
        {
            try
            {
                await _signInManager.SignOutAsync();
               // _logger.LogInformation("User logged out.");
                if (returnUrl != null)
                {//~/Identity/Login
                    return LocalRedirect(returnUrl);
                }
                else
                {//~/Identity/Login
                    returnUrl = Url.Content("~/Customer/Home/Index");//identity/Login/LogoutMethoud

                    return View("LogoutM");
                }
            }
            catch (Exception ex)
            {
               // _logger.LogError("Error News " + ex.Message.ToString());
                return View("LogoutM");
            }

        }
    }
}
