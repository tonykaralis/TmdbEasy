using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TmdbEasy.Apis;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public static class TmdbEasyServiceCollectionExtensions
    {
        public static IServiceCollection AddTmdbEasy(this IServiceCollection serviceCollection, TmdbEasyOptions options)
        {
            var sessionDescriptor = new ServiceDescriptor(
                    typeof(ITmdbEasyClient), c =>
                    {
                        return new TmdbEasyClient(options);

                    }, ServiceLifetime.Singleton);

            serviceCollection.TryAdd(sessionDescriptor);

            serviceCollection.AddScoped<IRequestHandler, RequestHandler>();

            serviceCollection.AddScoped<IReviewApi, ReviewApi>();
            serviceCollection.AddScoped<IChangesApi, ChangesApi>();
            serviceCollection.AddScoped<ICompaniesApi, CompaniesApi>();
            serviceCollection.AddScoped<ICollectionApi, CollectionApi>();
            serviceCollection.AddScoped<IConfigApi, ConfigApi>();
            serviceCollection.AddScoped<ICreditApi, CreditApi>();
            serviceCollection.AddScoped<IMovieApi, MovieApi>();
            serviceCollection.AddScoped<INetworksApi, NetworksApi>();
            serviceCollection.AddScoped<ITelevisionApi, TelevisionApi>();

            return serviceCollection;
        }
    }
}
