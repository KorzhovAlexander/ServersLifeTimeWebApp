using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServersLifeTimeWebApp.Data;

namespace ServersLifeTimeWebApp.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    // GET: home/getservers
    public async Task<IActionResult> GetServers() => Ok(await _context.Servers.AsNoTracking().ToListAsync());
}
