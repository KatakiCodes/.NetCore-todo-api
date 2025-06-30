using Microsoft.EntityFrameworkCore;
using TODO.Domain.Entities;

namespace TODO.Infra.DataContexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    public DbSet<TodoItem> Todos { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().Property(x => x.Id);
        modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160);
    }
}
