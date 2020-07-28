using System.Threading.Tasks;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class ReviewApi : IReviewApi
    {
        private readonly IRequestHandler _requestHandler;

        public ReviewApi(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public async Task<Review> GetReviewDetailsAsync(string reviewId, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"review/{reviewId}")
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteRequestAsync<Review>(restRequest);
        }
    }
}
