using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.API.Controllers
{
    public class TareasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
