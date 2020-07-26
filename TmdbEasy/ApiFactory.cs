using Microsoft.Extensions.DependencyInjection;
using System;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class ApiFactory : IApiFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ApiFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TApi GetApi<TApi>() where TApi : IBaseApi
        {
            return _serviceProvider.GetService<TApi>();
        }
    }
}
