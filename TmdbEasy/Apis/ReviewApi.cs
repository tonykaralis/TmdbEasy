using System.Threading.Tasks;
using TmdbEasy.Constants;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class ReviewApi : BaseApi, IReviewApi
    {
        public ReviewApi(ITmdbEasyClient client) : base(client) { }

        public async Task<Review> GetReviewDetailsAsync(ReviewRequest request)
        {
            string queryString = $"review/{request.Id}?{QueryConstants.ApiKeyVariable}{GetApiKey(request.UserApiKey)}";

            return await _client.GetResponseAsync<Review>(queryString).ConfigureAwait(false);
        }
    }
}
