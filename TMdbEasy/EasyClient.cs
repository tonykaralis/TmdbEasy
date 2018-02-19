using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy
{
    public sealed partial class EasyClient : ClientBase
    {
        private const string TmdbUrl = "http://api.themoviedb.org/";
        private const string TmdbUrlSsl = "https://api.themoviedb.org/";
        private const string ApiVersion = "3";

        public string ApiKey { get; private set; } = null;
        public bool Secured { get; private set; } = true;
        public string Url { get; private set; } = TmdbUrlSsl;

        /// <summary>
        /// In order to use the client you must provide the api key
        /// </summary>
        /// <param name="_apiKey">Tmdb Api key</param>
        /// <param name="_secure">Prefer ssl or not. Default set to true</param>
        public EasyClient(string _apiKey, bool _secure = true)
        {
            Initialize(_apiKey, _secure);
        }

        /// <summary>
        /// Setup the apikey and whether ssl is a choice or not
        /// </summary>
        /// <param name="_apikey"></param>
        /// <param name="_secure"></param>
        private void Initialize(string _apikey, bool _secure)
        {
            if(string.IsNullOrEmpty(_apikey) || string.IsNullOrWhiteSpace(_apikey))
            {
                throw new ArgumentException("_apikey");
            }
            else
            {
                ApiKey = _apikey;
                Secured = _secure;
            }

            Url = _secure ? TmdbUrlSsl : TmdbUrl;
        }                

        public async Task<Movie> GetMovieInfoAsync(string query)
        {
            var content = await CallApiAsync(query);
            var movie = DeserializeJson<Movie>(content);
            return movie;
        }
    }
}
