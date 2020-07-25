using System.Threading.Tasks;
using TmdbEasy.Data.Reviews;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class ReviewApi : BaseApi, IReviewApi
    {
        private readonly ITmdbEasyClient _client;

        public ReviewApi(ITmdbEasyClient client)
        {
            _client = client;
        }

        public async Task<Review> GetReviewDetailsAsync(string id, string apiKey = null)
        {
            string queryString = $"review/{id}";

            return await _client.GetResponseAsync<Review>(queryString, apiKey).ConfigureAwait(false);
        }
    }
}
