using System;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects.Other;

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

        /// <summary>
        /// The find method makes it easy to search for objects in the database by an external id. For example, an IMDB ID.
        /// This method will search all objects(movies, TV shows and people) and return the results in a single response.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="language">Default is english</param>
        /// <param name="external_id"></param>
        /// <returns></returns>
        public async Task<ObjectCollection> Find(string id, string external_id, string language = "en")
        {
            var content = await REngine.CallApiAsync($"{REngine.Url}find/{id}?api_key={REngine.ApiKey}&language={language}&external_source={external_id}").ConfigureAwait(false);
            return REngine.DeserializeJson<ObjectCollection>(content);
        }
    }
}
