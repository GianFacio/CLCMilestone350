using CLCMilestone.Models;
using Microsoft.AspNetCore.Mvc;


namespace CLCMilestone.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterDetails(Register register)
        {
            return View(register);
        }

        
    }
}
