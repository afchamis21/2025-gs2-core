using Microsoft.EntityFrameworkCore;
using ModelChanger.Entities;

namespace ModelChanger.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Model> Models { get; set; }
}
