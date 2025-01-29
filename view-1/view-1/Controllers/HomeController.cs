using Microsoft.AspNetCore.Mvc;

namespace view_1.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
