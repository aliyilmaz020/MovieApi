using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class MovieControllercs : Controller
    {
        public IActionResult MovieList()
        {
            return View();
        }
    }
}
