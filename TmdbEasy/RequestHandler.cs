using System.Threading.Tasks;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class RequestHandler : IRequestHandler
    {
        private readonly ITmdbEasyClient _client;

        public RequestHandler(ITmdbEasyClient client)
        {
            _client = client;           
        }

        public Request CreateRequest()
        {
            return new Request(_client.GetBaseUrl(), _client.GetApiKey(), _client.GetDefaultLanguage());
        }

        public async Task<TmdbEasyModel> ExecuteRequestAsync<TmdbEasyModel>(Request request)
        {
            return await _client.GetResponseAsync<TmdbEasyModel>(request.GetUri()).ConfigureAwait(false);
        }
    }
}
