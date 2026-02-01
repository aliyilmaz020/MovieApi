using Microsoft.AspNetCore.Mvc;

public class _AdminSidebarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}