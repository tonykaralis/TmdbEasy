using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.TmdbObjects;
using TMdbEasy.TmdbObjects.Collection;
using TMdbEasy.TmdbObjects.Images;

namespace TMdbEasy.ApiInterfaces
{
    public interface ICollectionApi
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
