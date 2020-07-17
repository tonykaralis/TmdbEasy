using System.Threading.Tasks;
using TmdbEasy.Data.Reviews;

namespace TmdbEasy.Interfaces
{
    public interface IReviewApi
    {
        /// <summary>
        /// Get the reviews for a specific review id
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>       
        /// <returns></returns>
        Task<Review> GetDetailsAsync(int id);
    }
}
