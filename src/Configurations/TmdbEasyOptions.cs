using TmdbEasy.Interfaces;

namespace TmdbEasy.Configurations
{
    public class TmdbEasyOptions
    {
        public TmdbEasyOptions(string apiKey = null, bool useSsl = true, string defaultLanguage = "en", IJsonDeserializer customJsonSerializer = null)
        {
            ApiKey = apiKey;
            UseSsl = useSsl;
            DefaultLanguage = defaultLanguage;
            JsonDeserializer = customJsonSerializer;
        }

        internal string ApiKey { get; }

        internal bool UseSsl { get; }

        internal string DefaultLanguage { get; }

        internal IJsonDeserializer JsonDeserializer { get; }
    }
}
