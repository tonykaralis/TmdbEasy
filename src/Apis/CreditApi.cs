using System.Threading.Tasks;
using TmdbEasy.DTO.Other;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class CreditApi : ICreditApi
    {
        private readonly IRequestHandler _requestHandler;

        public CreditApi(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public async Task<Credits> GetDetailsAsync(string creditId, string userApiKey = null)
        {
            var restRequest = _requestHandler
              .CreateRequest()
              .AddUrlSegment("credit")
              .AddUrlSegment(creditId)
              .AddApiKey(userApiKey);

            return await _requestHandler.ExecuteAsync<Credits>(restRequest);
        }
    }
}
