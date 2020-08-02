using System.Threading.Tasks;
using TmdbEasy.DTO.Changes;
using TmdbEasy.Enums;
using TmdbEasy.Extensions;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class ChangesApi : IChangesApi
    {
        private readonly IRequestHandler _requestHandler;
        private readonly ITmdbEasyClient _client;

        public ChangesApi(ITmdbEasyClient client)
        {            
            _client = client;
            _requestHandler = new RequestHandler(_client);
        }

        public async Task<ChangeList> GetChangeListAsync(ChangeType type, string end_date = null, string start_date = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment(type.ToString().ToLower())
                .AddUrlSegment($"changes")
                .AddPage(page)
                .AddApiKey(apiKey)
                .AddStartDate(start_date)
                .AddEndDate(end_date);

            return await _requestHandler.ExecuteAsync<ChangeList>(restRequest);
        }
    }
}
