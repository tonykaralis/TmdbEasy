using System;
using System.Net.Http;
using System.Threading.Tasks;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class TmdbEasyClientv3 : ITmdbEasyClient
    {
        private readonly IJsonDeserializer _jsonDeserializer;
        private readonly TmdbEasyOptions _options;
        private readonly HttpClient _httpClient;

        public TmdbEasyClientv3(IJsonDeserializer jsonDeserializer, TmdbEasyOptions options)
        {
            _jsonDeserializer = jsonDeserializer;
            _options = options;
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(GetUrl())
            };
        }

        public async Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query, string userAuthToken)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(TmdbEasyClientv3)} query param null or empty");

            var jsonResult = await _httpClient.GetStringAsync($"{query}?{Query.ApiKeyVariable}{userAuthToken}");

            return _jsonDeserializer.DeserializeTo<TmdbEasyModel>(jsonResult);
        }

        public ApiVersion GetVersion()
        {
            return _options.ApiVersion;
        }

        public string GetBaseUrl()
        {
            return _httpClient.BaseAddress.ToString();
        }

        private string GetUrl()
        {
            return _options.UseSsl ? Constants.TmdbUrl3Ssl : Constants.TmdbUrl3;
        }
    }
}
