using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using TODO.Domain.Handlers;
using TODO.Domain.Repositories;
using TODO.Infra.DataContexts;
using TODO.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
//Soving dependencies
builder.Services.AddDbContext<DataContext>(option => option.UseInMemoryDatabase("Database"));

builder.Services.AddTransient<ITodoItemRepository, TodoRepository>();
builder.Services.AddTransient<Handler, Handler>();
builder.Services.AddSwaggerGen();

//Add google authentication
builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}).AddCookie().AddGoogle(option =>
{
    option.ClientId = builder.Configuration["Authentication:Google:Client_Id"];
    option.ClientSecret = builder.Configuration["Authentication:Google:Client_Secret"];
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
