using System;
using System.Net.Http;
using System.Threading.Tasks;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class TmdbEasyClient : ITmdbEasyClient
    {
        private readonly IJsonDeserializer _jsonDeserializer;
        private readonly HttpClient _httpClient;

        public TmdbEasyClient(IJsonDeserializer jsonDeserializer, TmdbEasyOptions options)
        {
            _jsonDeserializer = jsonDeserializer;

            Options = options ?? throw new ArgumentNullException(nameof(options));

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Options.UseSsl ? Constants.TmdbUrl3Ssl : Constants.TmdbUrl3)
            };
        }

        public TmdbEasyOptions Options { get; }

        public async Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(TmdbEasyClient)} query param null or empty");

            string jsonResult = await _httpClient.GetStringAsync(query);

            return _jsonDeserializer.DeserializeTo<TmdbEasyModel>(jsonResult);
        }
    }
}
