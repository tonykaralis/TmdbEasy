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
                BaseAddress = new Uri(_options.UseSsl ? UrlConstants.TmdbUrl3Ssl : UrlConstants.TmdbUrl3)
            };
        }

        public async Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(TmdbEasyClientv3)} query param null or empty");

            var jsonResult = await _httpClient.GetStringAsync(query);

            return _jsonDeserializer.DeserializeTo<TmdbEasyModel>(jsonResult);
        }

        public ApiVersion GetVersion() => ApiVersion.v3;

        public string GetBaseUrl() => _httpClient.BaseAddress.ToString();

        public string GetApiKey() => _options.ApiKey;

        public string GetDefaultLanguage() => _options.DefaultLanguage;
    }
}
