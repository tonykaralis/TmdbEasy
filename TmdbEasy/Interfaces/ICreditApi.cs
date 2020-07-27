using System.Threading.Tasks;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Other;

namespace TmdbEasy.Interfaces
{
    public interface ICreditApi : IBaseApi
    {
        /// <summary>
        /// Get a movie or TV credit details by id.
        /// </summary>
        Task<Credits> GetDetailsAsync(IdRequest request);
    }
}
