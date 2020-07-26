using System.Threading.Tasks;
using TmdbEasy.Constants;
using TmdbEasy.Data.Reviews;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class ReviewApi : BaseApi, IReviewApi
    {
        public ReviewApi(ITmdbEasyClient client) : base(client) { }

        public async Task<Review> GetReviewDetailsAsync(string id, string userApiKey = null)
        {
            string queryString = $"review/{id}?{QueryConstants.ApiKeyVariable}{GetApiKey(userApiKey)}";

            return await _client.GetResponseAsync<Review>(queryString).ConfigureAwait(false);
        }
    }
}
