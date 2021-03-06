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
    public IActionResult GetCurrentDateTime() => Ok(DateTime.Now);

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

    [HttpPost]
    public async Task<IActionResult> RemoveServers([FromBody] DeletedServersDto deletedServers)
    {
        var servers = await _context.Servers
            .Where(server => 
                server.RemoveDate == null 
                &&
                deletedServers.SelectedIds.Contains(server.Id))
            .ToListAsync();
        
        var serverRemoveDate = DateTime.Now;

        servers.ForEach(server => server.RemoveDate = serverRemoveDate);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
