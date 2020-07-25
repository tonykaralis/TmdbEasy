using System;
using System.Net.Http;
using System.Threading.Tasks;
using TmdbEasy.Configurations;
using TmdbEasy.Constants;
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

            _options = options ?? throw new ArgumentNullException($"{nameof(TmdbEasyOptions)}");

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(GetUrl())
            };
        }

        public async Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query, string userApiKey = null)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(TmdbEasyClientv3)} query param null or empty");

            var jsonResult = await _httpClient.GetStringAsync($"{query}?{QueryConstants.ApiKeyVariable}{GetApiKey(userApiKey)}");

            return _jsonDeserializer.DeserializeTo<TmdbEasyModel>(jsonResult);
        }

        public ApiVersion GetVersion() => ApiVersion.v3;

        public string GetBaseUrl() => _httpClient.BaseAddress.ToString();

        public string GetApiKey() => _options.ApiKey;

        private string GetUrl()
        {
            return _options.UseSsl ? UrlConstants.TmdbUrl3Ssl : UrlConstants.TmdbUrl3;
        }

        private string GetApiKey(string userApiKey)
        {
            if(string.IsNullOrEmpty(userApiKey))
            {
                return !string.IsNullOrEmpty(_options.ApiKey) ? _options.ApiKey :
                    throw new ArgumentException("A valid api key is required in order to make requests to the TMDB api");
            }

            return userApiKey;
        }
    }
}
