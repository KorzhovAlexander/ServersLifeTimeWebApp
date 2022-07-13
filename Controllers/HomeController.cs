using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServersLifeTimeWebApp.Data;
using ServersLifeTimeWebApp.Data.Entity;

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

    [HttpGet]
    public async Task<IActionResult> GetTotalUsageTime()
    {
        var intervals = await _context.Servers
            .Select(server => new[] {server.CreateDate, server.RemoveDate ?? DateTime.Now})
            .ToArrayAsync();

        var intervalsSum = intervals
            .Merge()
            .Select(times => times[1] - times[0])
            .Aggregate(TimeSpan.Zero, (sumSoFar, next) => sumSoFar + next);
        return Ok(intervalsSum);
    }


    [HttpPost]
    public async Task<IActionResult> CreateServer()
    {
        var server = new Server
        {
            CreateDate = DateTime.Now
        };

        await _context.AddAsync(server);
        await _context.SaveChangesAsync();

        return StatusCode(StatusCodes.Status201Created, server.Id);
    }
    
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
