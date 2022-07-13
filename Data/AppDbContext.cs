using Microsoft.EntityFrameworkCore;

namespace ServersLifeTimeWebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
