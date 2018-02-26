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
        /// Gets all the information about a specific movie.
        /// </summary>
        /// <param name="movieId">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<Collections> GetDetailsAsync(int movieId, string language = "en");
        /// <summary>
        /// Returns all movies that belong to a movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<Images> GetImagesAsync(int id, string language = "en");
    }
}
