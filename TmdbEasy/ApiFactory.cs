using Microsoft.Extensions.DependencyInjection;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class ApiFactory : IApiFactory
    {
        private readonly IServiceCollection _serviceCollection;

        public ApiFactory(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public TApi GetApi<TApi>() where TApi : IBaseApi
        {
            return _serviceCollection.BuildServiceProvider().GetService<TApi>();
        }
    }
}
