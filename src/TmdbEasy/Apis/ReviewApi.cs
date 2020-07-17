using System.Threading.Tasks;
using TmdbEasy.Data.Reviews;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class ReviewApi : IReviewApi
    {
        private readonly ITmdbEasyClient _client;

        public ReviewApi(ITmdbEasyClient client)
        {
            _client = client;
        }

        public async Task<Review> GetDetailsAsync(int id)
        {
            string queryString = $"review/" +
                $"{id}?{Constants.ApiKeyParam}" +
                $"{Constants.OpenBraces}" +
                $"{Constants.ApiKeyPlaceholder}" +
                $"{Constants.CloseBraces}";

            return await _client.GetResponseAsync<Review>(queryString).ConfigureAwait(false);
        }
    }
}
