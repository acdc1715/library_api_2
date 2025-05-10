using Microsoft.Extensions.DependencyInjection;
using LibraryAPI.BL.Services;
using LibraryAPI.BL.Mappings;

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
