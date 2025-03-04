using Microsoft.Extensions.DependencyInjection;
using LibraryAPI.Repositories;
using LibraryAPI.Services;
using LibraryAPI.Mappings;

namespace BL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<IBooksService, BooksService>();
            services.AddScoped<IAuthorsService, AuthorsService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}
