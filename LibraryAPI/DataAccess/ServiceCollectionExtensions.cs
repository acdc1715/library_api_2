using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.BL.Interfaces;
using LibraryAPI.DataAccess.Repositories;

namespace LibraryAPI.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBookRepository, SQLBookRepository>();
            services.AddScoped<IAuthorRepository, SQLAuthorRepository>();
            services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}