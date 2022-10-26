using CLCMilestone.Models;
using CLCMilestone.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace CLCMilestone.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegistrationHandler(Register User)
        {
            SecurityDAO securityService = new SecurityDAO();
            return View(securityService.RegisterUser(User));
        }



    }
}
