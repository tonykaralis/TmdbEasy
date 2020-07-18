using System;
using System.Net.Http;
using System.Threading.Tasks;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class TmdbEasyClientv4 : ITmdbEasyClient
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

            request.Headers.Add(Constants.AuthHeaderName, $"Bearer {userAuthToken}");

            var responseMessage = await _httpClient.SendAsync(request);

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            return _jsonDeserializer.DeserializeTo<TmdbEasyModel>(jsonData);
        }

        public ApiVersion GetVersion()
        {
            return _options.ApiVersion;
        }

        public string GetBaseUrl()
        {
            return _options.UseSsl ? Constants.TmdbUrl4Ssl : Constants.TmdbUrl4;
        }
    }
}
