using Microsoft.EntityFrameworkCore;
using ServersLifeTimeWebApp.Data.Entity;

namespace ServersLifeTimeWebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Server> Servers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var serversTable = modelBuilder.Entity<Server>();

        serversTable
            .HasKey(server => server.Id)
            .HasName("VirtualServerId");
        serversTable
            .Property(server => server.CreateDate)
            .HasColumnName("CreateDateTime");
        serversTable
            .Property(server => server.RemoveDate)
            .HasColumnName("RemoveDateTime");


        serversTable.HasData(new List<Server>
        {
            new()
            {
                Id = 1,
                CreateDate = DateTime.Parse("2019-01-21 12:00:00"),
                RemoveDate = DateTime.Parse("2019-01-21 16:40:35"),
            },
            new()
            {
                Id = 2,
                CreateDate = DateTime.Parse("2019-01-21 12:40:00"),
                RemoveDate = DateTime.Parse("2019-01-21 16:40:35"),
            },
        });


        base.OnModelCreating(modelBuilder);
    }
}
