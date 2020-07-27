using System.Threading.Tasks;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Other;

namespace TmdbEasy.Interfaces
{
    public interface ICollectionApi : IBaseApi
    {
        /// <summary>
        /// Get collection details by id.
        /// </summary>
        Task<Collections> GetDetailsAsync(IdLanguageRequest request);
        /// <summary>
        /// Get the images for a collection by id.
        /// </summary>
        Task<Images> GetImagesAsync(IdLanguageRequest request);
    }
}
