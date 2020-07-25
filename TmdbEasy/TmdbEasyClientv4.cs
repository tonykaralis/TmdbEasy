using System;
using System.Net.Http;
using System.Threading.Tasks;
using TmdbEasy.Configurations;
using TmdbEasy.Constants;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    internal class TmdbEasyClientv4
    {
        private readonly IJsonDeserializer _jsonDeserializer;
        private readonly TmdbEasyOptions _options;
        private readonly HttpClient _httpClient;

        public TmdbEasyClientv4(IJsonDeserializer jsonDeserializer, TmdbEasyOptions options)
        {
            _jsonDeserializer = jsonDeserializer;
            _options = options;
            _httpClient = new HttpClient();
        }

        public async Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query, string userAuthToken)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(TmdbEasyClientv4)} query param null or empty");

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri($"{GetBaseUrl()}{query}"),
                Method = HttpMethod.Get,
            };

            request.Headers.Add(UrlConstants.AuthHeaderName, $"Bearer {userAuthToken}");

            var responseMessage = await _httpClient.SendAsync(request);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            return _jsonDeserializer.DeserializeTo<TmdbEasyModel>(jsonData);
        }

        public ApiVersion GetVersion() => ApiVersion.v4;

        public string GetBaseUrl() => _options.UseSsl ? UrlConstants.TmdbUrl4Ssl : UrlConstants.TmdbUrl4;
    }
}
