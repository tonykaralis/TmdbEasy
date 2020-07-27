using System.Threading.Tasks;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Reviews;

namespace TmdbEasy.Interfaces
{
    public interface IReviewApi : IBaseApi
    {
        Task<Review> GetReviewDetailsAsync(ReviewRequest request);
    }
}
