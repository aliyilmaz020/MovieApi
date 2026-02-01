using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
