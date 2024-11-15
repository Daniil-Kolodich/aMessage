using aMessage.Database.Repositories;
using aMessage.Database.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace aMessage.Database;

public static class DatabaseAssembly
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(
            o => o.UseSqlServer("Server=DESKTOP-D0G448O;Database=LocalDB;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true"));
        services.AddScoped<IUserRepository, UserRepository>();
    }
}