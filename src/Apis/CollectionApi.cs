using System.Threading.Tasks;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Other;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class CollectionApi : ICollectionApi
    {
        private readonly IRequestHandler _requestHandler;
        private readonly ITmdbEasyClient _client;

        public CollectionApi(ITmdbEasyClient client)
        {
            _client = client;
            _requestHandler = new RequestHandler(_client);
        }

        public async Task<Collections> GetDetailsAsync(int collectionId, string apiKey = null, string language = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"collection/{collectionId}")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<Collections>(restRequest);
        }

        public async Task<Images> GetImagesAsync(int collectionId, string apiKey = null, string language = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment($"collection/{collectionId}")
               .AddUrlSegment($"images")
               .AddLanguage(language)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<Images>(restRequest);
        }
    }
}
