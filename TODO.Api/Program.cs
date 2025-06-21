using Microsoft.EntityFrameworkCore;
using TODO.Infra.DataContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//Add dbcontext
builder.Services.AddDbContext<DataContext>(option => option.UseInMemoryDatabase("Database"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
