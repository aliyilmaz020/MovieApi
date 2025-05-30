using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.MovieDetailsViewComponents
{
    public class _MovieDetailOverviewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
