using System.Threading.Tasks;
using TmdbEasy.Data.Reviews;

namespace TmdbEasy.Interfaces
{
    public interface IReviewApi
    {
        Task<Review> GetReviewDetailsAsync(string id);
    }
}
