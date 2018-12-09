using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.TmdbObjects.Movies;

namespace TMdbEasy
{
    public static class REngine
    {
        #region Core Object properties and methods
        private const string TmdbUrl3 = "http://api.themoviedb.org/3/";
        private const string TmdbUrl3Ssl = "https://api.themoviedb.org/3/";

        public static string ApiKey { get; private set; } = null;
        public static bool Secured { get; private set; } = true;
        public static string Url { get; private set; } = TmdbUrl3Ssl;

        /// <summary>
        /// Setup the apikey and whether ssl is a choice or not
        /// </summary>
        /// <param name="_apikey"></param>
        /// <param name="_secure"></param>
        internal static void Initialize(string _apikey, bool _secure)
        {
            if (string.IsNullOrEmpty(_apikey) || string.IsNullOrWhiteSpace(_apikey))
            {
                throw new Exception("_apikey is null or empty");
            }
            else
            {
                CheckApiKeyValid(_apikey);
                ApiKey = _apikey;
                Secured = _secure;
                Url = _secure ? TmdbUrl3Ssl : TmdbUrl3;
            }
        }
        #endregion

        /// <summary>
        /// Deserialize any tmdb type and then return that type
        /// </summary>
        /// <typeparam name="T">Tmdb object type</typeparam>
        /// <param name="content">api call reponse string</param>
        /// <exception cref="JsonException">Occurs when the string can not
        /// be parsed to the given type.</exception>
        internal static T DeserializeJson<T>(string content)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<T>(content);
                return model;
            }
            catch (Exception ex)
            {
                throw new JsonException("Could not deserialize input string! " +
                    "See InnerException for more details.", ex);
            }
        }

        /// <summary>
        /// Accepts a ready built query string, calls the api Asynchronouslyand 
        /// then returns the response output as a string.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        internal async static Task<string> CallApiAsync(string query)
        {
            var request = (HttpWebRequest)WebRequest.Create(query);
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
                    using (var sr = new StreamReader(stream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch( WebException ex) when ((ex.Response as HttpWebResponse) ?.StatusCode == HttpStatusCode.NotFound )
            {
                throw new Exception("Possibly Movie Id does not exist");
            }
            catch( WebException ex) when ((ex.Response as HttpWebResponse) ?.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                throw new Exception("Most likely exceeded your rate limit");
            }
            catch( WebException ex) when ((ex.Response as HttpWebResponse) ?.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("Most likely you are using an invalid Api Key");
            }
            catch (Exception)
            {
                throw new Exception("Most likely you are passing invalid parameter data");
            }
        }

        /// <summary>
        /// Accepts a ready built query string, calls the api Synchronously and 
        /// then returns the response output as a string.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        internal static string CallApi(string query)
        {
            var request = (HttpWebRequest)WebRequest.Create(query);
            request.Method = "GET";
            //request.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 57.0) Gecko / 20100101 Firefox / 57.0";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            WebResponse response;
            try
            {
                response = request.GetResponse()
                    as HttpWebResponse;
                using (Stream stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Movie Id does not exist");
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                throw new Exception("Most likely exceeded your rate limit");
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("Most likely you are using an invalid Api Key");
            }
            catch (Exception)
            {
                throw new Exception("Most likely you are passing invalid parameter data");
            }
        }

        private static void CheckApiKeyValid(string key)
        {
            string query = $"{Url}movie/296096?api_key={key}&language=en";
            CallApi(query);
        }
    }
}