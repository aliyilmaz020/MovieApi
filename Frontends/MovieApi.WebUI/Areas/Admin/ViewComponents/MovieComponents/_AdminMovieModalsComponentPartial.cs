using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Areas.Admin.ViewComponents.MovieComponents;

public class _AdminMovieModalsComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
