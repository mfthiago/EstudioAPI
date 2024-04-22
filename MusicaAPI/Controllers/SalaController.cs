using Microsoft.AspNetCore.Mvc;

namespace MusicaAPI.Controllers
{
    public class SalaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
