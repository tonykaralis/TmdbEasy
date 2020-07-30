using System.Threading.Tasks;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Other;

namespace TmdbEasy.Interfaces
{
    public interface ICollectionApi
    {
        /// <summary>
        /// Get collection details by id.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="apiKey"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        Task<Collections> GetDetailsAsync(int collectionId, string apiKey = null, string language = null);
        /// <summary>
        /// Get the images for a collection by id.
        /// </summary>
        /// <param name="collectionId"></param>
        /// <param name="apiKey"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        Task<Images> GetImagesAsync(int collectionId, string apiKey = null, string language = null);
    }
}
