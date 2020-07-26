using System;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public abstract class BaseApi
    {
        protected readonly ITmdbEasyClient _client;

        protected BaseApi(ITmdbEasyClient client)
        {
            _client = client;
        }

        public string GetApiKey(string userApiKey = null)
        {
            if (string.IsNullOrEmpty(userApiKey))
            {
                return !string.IsNullOrEmpty(_client.GetApiKey()) ? _client.GetApiKey() :
                    throw new ArgumentException("A valid api key is required in order to make requests to the TMDB api");
            }

            return userApiKey;
        }
    }
}
