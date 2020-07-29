namespace TmdbEasy.Configurations
{
    public class TmdbEasyOptions
    {
        private const string _tmdbUrl3 = "http://api.themoviedb.org/3";
        private const string _tmdbUrl3Ssl = "https://api.themoviedb.org/3";

        public TmdbEasyOptions(string apiKey, bool useSsl = true, string defaultLanguage = "en")
        {
            ApiKey = apiKey;
            BaseUri = useSsl ? _tmdbUrl3Ssl : _tmdbUrl3;
            DefaultLanguage = defaultLanguage;
        }

        internal string ApiKey { get; }

        internal string BaseUri { get; }

        internal string DefaultLanguage { get; }
    }
}
