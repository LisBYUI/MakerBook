using Microsoft.AspNetCore.Mvc;
using MakerBook.Models;

namespace MakerBook.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (loginModel.Login == "lisalves@gmail.com" && loginModel.Password == "123456")

                        return RedirectToAction("Index", "Home");

                    //TempData["ErrorMessage"] = "Invalid login!";
                }
                return View("Index");
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }
    }
}
