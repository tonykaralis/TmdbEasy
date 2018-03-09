using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.TmdbObjects.Movies;
using TMdbEasy.TmdbObjects.Images;
using TMdbEasy.TmdbObjects.Changes;
using TMdbEasy.TmdbObjects.Other;
using TMdbEasy.TmdbObjects.Language;

namespace TMdbEasy.ApiInterfaces
{
    public interface IMovieApi : IBase
    {
        /// <summary>
        /// Gets all the information about a specific movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<MovieFullDetails> GetDetailsAsync(int id, string language = "en");
        /// <summary>
        /// Returns all movies that belong to a movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<Images> GetImagesAsync(int id, string language = "en");
        /// <summary>
        /// Returns all alternative titles that belong to a movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="country">Pass a ISO_3166_1 value to display translated data for the fields that support it. Default is Britain</param>
        /// <returns></returns>
        Task<AlternativeTitle> GetAlternativeTitlesAsync(int id, string country = "BR");
        /// <summary>
        /// Get the changes for a movie. By default only the last 24 hours are returned.
        /// You can query up to 14 days in a single query by using the start_date and end_date query parameters.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <param name="page"></param>       
        /// <returns></returns>
        Task<MovieChangeList> GetChangesAsync(int id, string start_date, string end_date, int page);
        /// <summary>
        /// Get the cast and crew for a movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>        
        /// <returns></returns>
        Task<MovieCredits> GetCreditsAsync(int id);
        /// <summary>
        /// Get the external ids for a movie. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>       
        /// <returns></returns>
        Task<MovieExternalId> GetExternalIdsAsync(int id);
        /// <summary>
        /// Get the release date along with the certification for a movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>      
        /// <returns></returns>
        Task<MovieReleaseDateList> GetReleaseDatesAsync(int id);
        /// <summary>
        /// Get the videos that have been added to a movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>        
        /// <returns></returns>
        Task<VideoList> GetVideosAsync(int id);
        /// <summary>
        /// Returns all alternative titles that belong to a movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>       
        /// <returns></returns>
        Task<TranslationsList> GetTranslationsAsync(int id);
        /// <summary>
        /// Get a list of recommended movies for a movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Default is English</param>
        /// <param name="page">Default is 1</param>     
        /// <returns></returns>
        Task<MovieList> GetRecommendationssAsync(int id, string language="en", int page=1);
    }
}
