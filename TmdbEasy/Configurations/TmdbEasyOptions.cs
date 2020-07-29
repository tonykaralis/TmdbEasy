namespace TmdbEasy.Configurations
{
    public class TmdbEasyOptions
    {
        private const string _tmdbUrl3 = "http://api.themoviedb.org/3";
        private const string _tmdbUrl3Ssl = "https://api.themoviedb.org/3";

        public bool UseSsl { get; set; }

        public string ApiKey { get; set; }

        public string DefaultLanguage { get; set; }

        public string GetBaseUrl() => UseSsl ? _tmdbUrl3Ssl : _tmdbUrl3;
    }
}
