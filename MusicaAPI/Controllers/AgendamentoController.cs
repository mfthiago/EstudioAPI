using Microsoft.AspNetCore.Mvc;

namespace MusicaAPI.Controllers
{
    public class AgendamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
