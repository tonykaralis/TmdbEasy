using System;
using System.Text;
using TmdbEasy.Configurations;

namespace TmdbEasy
{
    public sealed class Request
    {
        private readonly StringBuilder _requestBuilder;
        private readonly TmdbEasyOptions _options;
        private bool _firstParameterAdded;

        public Request(TmdbEasyOptions options)
        {
            _requestBuilder = new StringBuilder();
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Adds a forward slash followed by the url segment as is if not null or empty
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public Request AddUrlSegment(string segment)
        {
            if (string.IsNullOrEmpty(segment))
                return this;

            if (_requestBuilder.ToString().Length == 0)
                _requestBuilder.Append(segment);
            else
                _requestBuilder.Append("/").Append(segment);

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
            string languageToAdd = !string.IsNullOrEmpty(language) ? language : _options.DefaultLanguage;

            return AddParameter("language", languageToAdd);
        }

        /// <summary>
        /// Adds the given apikey. If no apikey has been appended it will add the default api key if one exists.
        /// </summary>
        /// <returns></returns>
        public Request AddApiKey(string apiKey = null)
        {
            string apiKeyToAdd = !string.IsNullOrEmpty(apiKey) ? apiKey : _options.ApiKey;

            return AddParameter("api_key", apiKeyToAdd);
        }

        public string GetUri() => _requestBuilder.ToString();
    }
}
