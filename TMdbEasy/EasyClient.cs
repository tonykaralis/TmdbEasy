using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy
{
    public sealed class EasyClient : IDisposable
    {
        #region Singleton stuff
        private static readonly Lazy<EasyClient> lazy = new Lazy<EasyClient>(() => new EasyClient());

        public static EasyClient Instance { get { return lazy.Value; } }

        private EasyClient()
        {
        }
        #endregion
        private const string TmdbUrl = "http://api.themoviedb.org/";
        private const string TmdbUrlSsl = "https://api.themoviedb.org/";
        private const string ApiVersion = "3";

        public string ApiKey { get; private set; } = null;
        public bool Secured { get; private set; } = true;
        public string Url { get; private set; } = TmdbUrlSsl;

        private HttpWebRequest Request;
        private HttpWebRequest Response; 


        /// <summary>
        /// In order to use the client you must provide the api key
        /// </summary>
        /// <param name="_apiKey">Tmdb Api key</param>
        /// <param name="_secure">Prefer ssl or not. Default set to true</param>
        public void SetupClient(string _apiKey, bool _secure = true)
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
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
