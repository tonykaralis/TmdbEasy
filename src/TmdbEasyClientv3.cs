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
        private readonly HttpClient _httpClient;
        private static readonly  string _tmdbUrl3 = "http://api.themoviedb.org/3/";
        private static readonly string _tmdbUrl3Ssl = "https://api.themoviedb.org/3/";

        public TmdbEasyClientv3(IJsonDeserializer jsonDeserializer, TmdbEasyOptions options)
        {
            _jsonDeserializer = jsonDeserializer;

            Options = options ?? throw new ArgumentNullException(nameof(options));

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Options.UseSsl ? _tmdbUrl3Ssl : _tmdbUrl3)
            };
        }

        public TmdbEasyOptions Options { get; }

        public async Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query)
        {
            if (string.IsNullOrEmpty(query) || string.IsNullOrWhiteSpace(query))
                throw new ArgumentException($"{nameof(TmdbEasyClientv3)} query param null or empty");

            string jsonResult = await _httpClient.GetStringAsync(query);

            return _jsonDeserializer.DeserializeTo<TmdbEasyModel>(jsonResult);
        }

        public ApiVersion GetVersion() => ApiVersion.v3;
    }
}
