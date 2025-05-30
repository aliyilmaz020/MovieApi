using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.MovieDetailsViewComponents
{
    public class _MovieDetailCastComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
