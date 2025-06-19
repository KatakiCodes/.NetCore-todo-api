using System;
using Microsoft.EntityFrameworkCore;
using TODO.Domain.Entities;

namespace TODO.Infra.DataContexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<TodoItem> Todos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().Property(x => x.Id);
        modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120);
        modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160);
        modelBuilder.Entity<TodoItem>().HasIndex(b=>b.User);
    }
}
