using System.Threading.Tasks;
using TmdbEasy.DTO.Other;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class NetworksApi : INetworksApi
    {
        private readonly IRequestHandler _requestHandler;
        private readonly ITmdbEasyClient _client;

        public NetworksApi(ITmdbEasyClient client)
        {
            _client = client;
            _requestHandler = new RequestHandler(_client);
        }

        public async Task<Network> GetDetailsAsync(int networkId, string userApiKey)
        {
            var restRequest = _requestHandler
             .CreateRequest()
             .AddUrlSegment("network")
             .AddUrlSegment($"{networkId}")
             .AddApiKey(userApiKey);

            return await _requestHandler.ExecuteAsync<Network>(restRequest);
        }
    }
}
