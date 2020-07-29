using System.Text;

namespace TmdbEasy
{
    public sealed class Request
    {
        private readonly StringBuilder _requestBuilder;
        private readonly string _defaultApiKey;
        private readonly string _defaultLanguage;
        private bool _firstParameterAdded;

        public Request(string baseUrl, string defaultApiKey, string defaultLanguage)
        {
            _requestBuilder = new StringBuilder(baseUrl);
            _defaultApiKey = defaultApiKey;
            _defaultLanguage = defaultLanguage;
        }

        /// <summary>
        /// Adds a forward slash followed by the url segment as is if not null or empty
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public Request AddUrlSegment(string segment)
        {
            if (!string.IsNullOrEmpty(segment))
                _requestBuilder.Append($"/{segment}");

            return this;
        }

        /// <summary>
        /// Adds the given key and value if both are not null or empty. 
        /// Appends either ? or & depending on whether another parameter was previously added.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Request AddParameter(string key, string value)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                return this;

            if (!_firstParameterAdded)
            {
                _requestBuilder.Append("?");
                _firstParameterAdded = true;
            }
            else
            {
                _requestBuilder.Append("&");
            }

            _requestBuilder.Append($"{key}={value}");

            return this;
        }

        /// <summary>
        /// Adds the given language. 
        /// If the lanugage is null or empty, it will attempt to add the default language
        /// </summary>
        /// <returns></returns>
        public Request AddLanguage(string language = null)
        {
            string languageToAdd = !string.IsNullOrEmpty(language) ? language : _defaultLanguage;

            return AddParameter("language", languageToAdd);
        }

        /// <summary>
        /// Adds the given apikey. If no apikey has been appended it will add the default api key if one exists.
        /// </summary>
        /// <returns></returns>
        public Request AddApiKey(string apiKey = null)
        {
            string apiKeyToAdd = !string.IsNullOrEmpty(apiKey) ? apiKey : _defaultApiKey;

            return AddParameter("api_key", apiKeyToAdd);
        }

        public string GetUri() => _requestBuilder.ToString();
    }
}
