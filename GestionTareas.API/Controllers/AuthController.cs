using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
