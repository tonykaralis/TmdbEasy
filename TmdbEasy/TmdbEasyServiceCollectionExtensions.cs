using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TmdbEasy.Apis;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public static class TmdbEasyServiceCollectionExtensions
    {
        public static IServiceCollection AddTmdbEasyClient(this IServiceCollection serviceCollection, TmdbEasyOptions options)
        {
            var sessionDescriptor = new ServiceDescriptor(
                    typeof(ITmdbEasyClient), c =>
                    {
                        var jsonDeserializer = c.GetService<IJsonDeserializer>();

                        return new TmdbEasyClientv3(jsonDeserializer, options);

                    }, ServiceLifetime.Singleton);

            serviceCollection.TryAdd(sessionDescriptor);

            return serviceCollection;
        }

        public static IServiceCollection UseTmdbEasyApiv3(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRequestHandler, RequestHandler>();
            serviceCollection.AddScoped<IJsonDeserializer, NewtonSoftDeserializer>();            

            serviceCollection.AddScoped<IReviewApi, ReviewApi>();
            serviceCollection.AddScoped<IChangesApi, ChangesApi>();
            serviceCollection.AddScoped<ICompaniesApi, CompaniesApi>();
            serviceCollection.AddScoped<ICollectionApi, CollectionApi>();
            serviceCollection.AddScoped<IConfigApi, ConfigApi>();

            return serviceCollection;
        }
    }
}
