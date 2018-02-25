using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy
{
    public static class REngine
    {
        #region Core Object properties and methods
        private const string TmdbUrl = "http://api.themoviedb.org/";
        private const string TmdbUrlSsl = "https://api.themoviedb.org/";
        private const string ApiVersion = "3";

        public static string ApiKey { get; private set; } = null;
        public static bool Secured { get; private set; } = true;
        public static string Url { get; private set; } = TmdbUrlSsl;

        /// <summary>
        /// Setup the apikey and whether ssl is a choice or not
        /// </summary>
        /// <param name="_apikey"></param>
        /// <param name="_secure"></param>
        internal static void Initialize(string _apikey, bool _secure)
        {
            if (string.IsNullOrEmpty(_apikey) || string.IsNullOrWhiteSpace(_apikey))
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
        #endregion

        /// <summary>
        /// Deserialize any tmdb type and then return that type
        /// </summary>
        /// <typeparam name="T">Tmdb object type</typeparam>
        /// <param name="content">api call reponse string</param>
        /// <returns></returns>
        internal static T DeserializeJson<T>(string content)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<T>(content);
                return model;
            }
            catch
            {
                throw new JsonException();
            }
        }

        /// <summary>
        /// Accepts a ready built query string, calls the api async and 
        /// then returns the response output as a string.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        internal async static Task<string> CallApiAsync(string query)
        {
            string result;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(query);
            request.Method = "GET";
            //request.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 57.0) Gecko / 20100101 Firefox / 57.0";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            WebResponse response;
            try
            {
                response = await request.GetResponseAsync().ConfigureAwait(false)
                    as HttpWebResponse;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        result = sr.ReadToEnd();
                        return result;
                    }
                }
            }
            catch
            {
                return null;
            }            
        }        
    }
}