using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.ApiObjects;
using TMdbEasy.TmdbObjects.Movies;

namespace TMdbEasy
{
    public sealed class EasyClient : ICreator
    {
        /// <summary>
        /// In order to use the client you must provide the api key
        /// </summary>
        /// <param name="_apiKey">Tmdb Api key</param>
        /// <param name="_secure">Prefer ssl or not. Default set to true</param>
        public EasyClient(string _apiKey, bool _secure = true)
        {
            REngine.Initialize(_apiKey, _secure);
        }

        public Lazy<T> GetApi<T>() where T : IBase
        {
            var apiMapper = new ApiCreator();
            return new Lazy<T>(apiMapper.CreateApi<T>);
        }
    }
}
