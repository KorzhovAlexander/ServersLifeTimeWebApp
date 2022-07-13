using Microsoft.AspNetCore.Mvc;

namespace ServersLifeTimeWebApp.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}
