using System.ComponentModel.DataAnnotations;
using aMessage.Domain;
using aMessage.Domain.Authentication.Services;

var builder = WebApplication.CreateBuilder(args);

DomainAssembly.ConfigureServices(builder.Services);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/register", async (string userName, string email, string password,IAuthenticationService authService) =>
{
    return await authService.Register(userName, email, password);
}).WithOpenApi();
app.MapPost("/login", async (string email, string password, IAuthenticationService authService) =>
{
    return await authService.Login(email, password);
}).WithOpenApi();

app.Run();
