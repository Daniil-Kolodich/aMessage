using System.ComponentModel.DataAnnotations;
using System.Text;
using aMessage.Domain;
using aMessage.Domain.Authentication.Services;
using aMessage.Domain.Shared;
using aMessage.Web.Configurations;
using aMessage.Web.Helpers;
using aMessage.Web.Helpers.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

DomainAssembly.ConfigureServices(builder.Services);

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection(nameof(JwtConfiguration)));
builder.Services.AddScoped<IJwtHelper, JwtHelper>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        var config = builder.Configuration.GetSection(nameof(JwtConfiguration)).Get<JwtConfiguration>();
        opt.RequireHttpsMetadata = true;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = config.Issuer,
            ValidateIssuer = true,
            ValidAudience = config.Audience,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.SecurityKey)),
            ValidateLifetime = true
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "aMessage", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapPost("/register", async (
        string userName, 
        string email, 
        string password,
        IAuthenticationService authService,
        IJwtHelper jwtHelper) =>
{
    var user = await authService.Register(userName, email, password);
    var token = jwtHelper.GenerateToken(user.Id);    
    return new
    {
        User = user,
        JWT = token
    };
}).AllowAnonymous().WithOpenApi();
app.MapPost("/login", async (
    string email,
    string password,
    IAuthenticationService authService,
    IJwtHelper jwtHelper) =>
{
    var user = await authService.Login(email, password);
    var token = jwtHelper.GenerateToken(user.Id);    
    return new
    {
        User = user,
        JWT = token
    };
}).AllowAnonymous()
    .WithOpenApi();

app.MapGet("/hello", (IIdentityService identityService) =>
    {
        return $"Hello user with id {identityService.UserId}";
    }
).RequireAuthorization();

app.Run();
