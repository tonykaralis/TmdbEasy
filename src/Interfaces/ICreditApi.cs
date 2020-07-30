using System.Threading.Tasks;
using TmdbEasy.DTO.Other;

namespace TmdbEasy.Interfaces
{
    public interface ICreditApi
    {
        /// <summary>
        /// Get movie or TV credit details by id.
        /// </summary>
        /// <param name="creditId"></param>
        /// <param name="apiKey">Optional</param>
        /// <returns></returns>
        Task<Credits> GetDetailsAsync(int creditId, string apiKey = null);
    }
}
