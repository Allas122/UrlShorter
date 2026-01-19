using Microsoft.EntityFrameworkCore;
using URLShorter.Domain.Entities;
using URLShorter.Infrastructure.EntityConfiguration;

namespace URLShorter.Infrastructure.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<UrlEntity> Urls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UrlEntityConfigurator).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var basePath = AppContext.BaseDirectory;
        var dbDirectory = Path.Combine(basePath, "DB");
        optionsBuilder.UseSqlite($"Data Source={dbDirectory}URLShorter.db");
    }
}