using Microsoft.EntityFrameworkCore;

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
        serversTable
            .Property(server => server.IsSelectedForRemove)
            .HasColumnName("SelectedForRemove");


        base.OnModelCreating(modelBuilder);
    }
}
