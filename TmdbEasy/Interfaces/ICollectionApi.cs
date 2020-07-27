using System.Threading.Tasks;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Other;

namespace TmdbEasy.Interfaces
{
    public interface ICollectionApi : IBaseApi
    {
        /// <summary>
        /// Get collection details by id.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<Collections> GetDetailsAsync(int id, string language = "en");
        /// <summary>
        /// Get the images for a collection by id.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<Images> GetImagesAsync(int id, string language = "en");
    }
}
