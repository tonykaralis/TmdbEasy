using Microsoft.Extensions.DependencyInjection;

namespace TmdbEasy
{
    public static class TmdbEasyServiceCollectionExtensions
    {
        public static IServiceCollection AddTmdbEasyClient(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
