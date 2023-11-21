using CubitsDomain.Interfaces;
using CubitsInfrastructure.DataBase;
using CubitsInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CubitsInfrastructure
{
    public static class Installer
    {
        public static void InstallRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}