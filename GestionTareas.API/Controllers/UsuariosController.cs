using Microsoft.AspNetCore.Mvc;

namespace GestionTareas.API.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
