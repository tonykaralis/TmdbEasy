using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class BaseApi : IBaseApi
    {
        protected string ApiKey { get; private set; }

        public void SetApiKey(string apiKey)
        {
            ApiKey = apiKey;
        }
    }
}
