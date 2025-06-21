using Microsoft.EntityFrameworkCore;
using TODO.Domain.Handlers;
using TODO.Domain.Repositories;
using TODO.Infra.DataContexts;
using TODO.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Soving dependencies
builder.Services.AddDbContext<DataContext>(option => option.UseInMemoryDatabase("Database"));

builder.Services.AddTransient<ITodoItemRepository, TodoRepository>();
builder.Services.AddTransient<Handler, Handler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
