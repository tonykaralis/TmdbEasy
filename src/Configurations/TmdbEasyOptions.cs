namespace TmdbEasy.Configurations
{
    public class TmdbEasyOptions
    {
        public TmdbEasyOptions(string apiKey = null, bool useSsl = true, string defaultLanguage = "en")
        {
            ApiKey = apiKey;
            UseSsl = useSsl;
            DefaultLanguage = defaultLanguage;
        }

        internal string ApiKey { get; }

        internal bool UseSsl { get; }

        internal string DefaultLanguage { get; }
    }
}
