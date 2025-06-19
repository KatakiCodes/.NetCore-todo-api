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
}
