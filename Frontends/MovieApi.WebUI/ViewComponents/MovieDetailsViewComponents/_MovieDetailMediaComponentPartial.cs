using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.MovieDetailsViewComponents
{
    public class _MovieDetailMediaComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
