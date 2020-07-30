using System.Threading.Tasks;
using TmdbEasy.DTO.Reviews;

namespace TmdbEasy.Interfaces
{
    public interface IReviewApi
    {
        /// <summary>
        /// Get review details by Id
        /// </summary>
        /// <param name="reviewId"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<Review> GetReviewDetailsAsync(string reviewId, string apiKey = null);
    }
}
