using Microsoft.AspNetCore.Mvc;

namespace MusicaAPI.Controllers
{
    public class EstudioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
