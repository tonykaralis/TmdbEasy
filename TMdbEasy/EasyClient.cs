using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.ApiObjects;
using TMdbEasy.TmdbObjects.Movies;

namespace TMdbEasy
{
    public sealed partial class EasyClient
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

        #region Api Objects
        public IMovieApi MovieApi { get; private set; } = new MovieApi();
        
        #endregion       
    }
}
