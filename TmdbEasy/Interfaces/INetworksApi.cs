using System.Threading.Tasks;
using TmdbEasy.DTO.Other;

namespace TmdbEasy.Interfaces
{
    public interface INetworksApi
    {
        /// <summary>
        /// Get the details of a network.
        /// </summary>
        /// <param name="creditId"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<Network> GetDetailsAsync(int creditId, string apiKey = null);
    }
}
