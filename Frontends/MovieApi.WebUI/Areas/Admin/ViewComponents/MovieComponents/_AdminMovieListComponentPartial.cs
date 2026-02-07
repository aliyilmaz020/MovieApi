using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Areas.Admin.ViewComponents.MovieComponents;

public class _AdminMovieListComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
