using LibraryAPI.Data;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IBlobStorageService, BlobStorageService>();
            return services;
        }
    }
}
