using System.Threading.Tasks;

namespace TmdbEasy.Interfaces
{
    public interface ICreditApi : IBaseApi
    {
        /// <summary>
        /// Get a movie or TV credit details by id.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>       
        /// <returns></returns>
        Task<Credits> GetDetailsAsync(int id);
    }
}
