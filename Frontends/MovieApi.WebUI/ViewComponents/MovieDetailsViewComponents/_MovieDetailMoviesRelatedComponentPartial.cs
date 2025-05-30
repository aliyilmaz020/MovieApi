using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.MovieDetailsViewComponents
{
    public class _MovieDetailMoviesRelatedComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
