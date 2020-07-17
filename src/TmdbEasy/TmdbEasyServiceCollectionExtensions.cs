using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TmdbEasy.Apis;
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
                        return new TmdbEasyClient(jsonDeserializer, options);
                    }, ServiceLifetime.Singleton);

            serviceCollection.TryAdd(sessionDescriptor);

            return serviceCollection;
        }

        public static IServiceCollection UseTmdbEasyApi(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IJsonDeserializer, NewtonSoftDeserializer>();
            serviceCollection.AddScoped<IApiFactory, ApiFactory>();

            serviceCollection.AddScoped<IReviewApi, ReviewApi>();


            return serviceCollection;
        }
    }
}
