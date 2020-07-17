using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class TmdbEasyClient : ITmdbEasyClient
    {
        private readonly TmdbEasyOptions _options;
        private readonly IJsonDeserializer _jsonDeserializer;

        public TmdbEasyClient(IJsonDeserializer jsonDeserializer, TmdbEasyOptions options)
        {
            _jsonDeserializer = jsonDeserializer;
            _options = options;
        }

        public string GetApiKey()
        {
            return string.IsNullOrEmpty(_options.ApiKey) ? throw new NullReferenceException($"{nameof(_options.ApiKey)}") : _options.ApiKey;
        }

        public string GetUrl()
        {
            return _options.UseSsl ? Constants.TmdbUrl3Ssl : Constants.TmdbUrl3;
        }

        public async Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query)
        {
            var request = (HttpWebRequest)WebRequest.Create(query);

            request.Method = "GET";

            //request.UserAgent = "Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 57.0) Gecko / 20100101 Firefox / 57.0";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            WebResponse response = await request.GetResponseAsync().ConfigureAwait(false) as HttpWebResponse;

            using (Stream stream = response.GetResponseStream())
            using (var sr = new StreamReader(stream))
            {
                var jsonResult = sr.ReadToEnd();
                return _jsonDeserializer.DeserializeTo<TmdbEasyModel>(jsonResult);
            }
        }
    }
}
