using System.Threading.Tasks;
using TmdbEasy.Data.Reviews;

namespace TmdbEasy.Interfaces
{
    public interface IReviewApi : IBaseApi
    {
        Task<Review> GetReviewDetailsAsync(string id, string apiKey = null);
    }
}
