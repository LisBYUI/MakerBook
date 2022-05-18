using MakerBook.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MakerBook.Controllers
{
    [PageForUserLogged]
    public class RestrictedAccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
