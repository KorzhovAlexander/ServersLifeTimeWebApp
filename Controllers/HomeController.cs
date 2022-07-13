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
    [HttpGet]
    public async Task<IActionResult> GetServers() => Ok(await _context.Servers.AsNoTracking().ToListAsync());

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveServer(int id)
    {
        var server = await _context.Servers.FindAsync(id);

        if (server is null) return NotFound();

        server.IsSelectedForRemove = true;
        await _context.SaveChangesAsync();

        //todo: removing server job start
        return Ok();
    }
}
