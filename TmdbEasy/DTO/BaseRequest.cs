namespace TmdbEasy.DTO
{
    public abstract class BaseRequest
    {
        /// <summary>
        /// Optional parameter. You would only use this parameter if you were providing a user specific api key
        /// on each request. If this is not the case, and you are using a single apikey for the entire app, 
        /// then please set apikey globally via the TmdbEasyOptions configuration
        /// </summary>
        public string UserApiKey { get; set; }
    }
}
