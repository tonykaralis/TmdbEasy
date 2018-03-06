using System;
using TMdbEasy.ApiInterfaces;

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

        /// <summary>
        /// Creates and returns an Api Interface of type Lazy<T>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Lazy<T> GetApi<T>() where T : IBase
        {
            var apiMapper = new ApiCreator();
            return new Lazy<T>(apiMapper.CreateApi<T>);
        }
    }
}
