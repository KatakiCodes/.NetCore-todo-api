using System;
using Microsoft.EntityFrameworkCore;

namespace TODO.Infra.DataContexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext>options): base(options)
    {
        
    }
}
