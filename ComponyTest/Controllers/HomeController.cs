using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

    }
    }

