using Microsoft.AspNetCore.Mvc;
namespace MovieApi.WebUI.ViewComponents.MovieDetailsViewComponents
{
    public class _MovieImageAndWatchTrailerComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
