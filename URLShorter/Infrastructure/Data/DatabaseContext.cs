using Microsoft.EntityFrameworkCore;
using URLShorter.Domain.Entities;
using URLShorter.Infrastructure.EntityConfiguration;

namespace URLShorter.Infrastructure.Data;

public class DatabaseContext : DbContext
{
    public DbSet<UrlEntity> Urls { get; set; }
    public DatabaseContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UrlEntityConfigurator).Assembly);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=URLShorter.db");
    }
}