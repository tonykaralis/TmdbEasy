using System.Threading.Tasks;
using TmdbEasy.DTO.Other;

namespace TmdbEasy.Interfaces
{
    public interface INetworksApi : IBaseApi
    {
        /// <summary>
        /// Get the details of a network.
        /// </summary>
        /// <param name="id">Network Id, typically taken from a previous api call</param>       
        /// <returns></returns>
        Task<Network> GetDetailsAsync(int id);
    }
}
