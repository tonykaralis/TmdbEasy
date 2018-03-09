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
        Task<MovieList> GetRecommendationsAsync(int id, string language="en", int page=1);
        /// <summary>
        /// Get a list of similar movies. This is not the same as the "Recommendation" system you see on the website.
        /// These items are assembled by looking at keywords and genres.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Default is English</param>
        /// <param name="page">Default is 1</param>     
        /// <returns></returns>
        Task<MovieList> GetSimilarMoviesAsync(int id, string language = "en", int page = 1);
        /// <summary>
        /// Get the user reviews for a movie.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Default is English</param>
        /// <param name="page">Default is 1</param>     
        /// <returns></returns>
        Task<UserReviews> GetUserReviewsAsync(int id, string language = "en", int page = 1);
        /// <summary>
        /// Get the most newly created movie. This is a live response and will continuously change.
        /// </summary>      
        /// <param name="language">Default is English</param>            
        /// <returns></returns>
        Task<MovieFullDetails> GetLatestAsync(string language = "en");
        /// <summary>
        /// Get a list of movies in theatres. This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>       
        /// <param name="language">Default is English</param>
        /// <param name="page">Default is 1</param>
        /// <param name="region">ISO 3166-1 code. Default is US</param>     
        /// <returns></returns>
        Task<DatedMovieList> GetNowPlayingAsync(string language = "en", int page = 1, string region="US");
        /// <summary>
        /// Get a list of the current popular movies on TMDb. This list updates daily.
        ///  /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>       
        /// <param name="language">Default is English</param>
        /// <param name="page">Default is 1</param>
        /// <param name="region">ISO 3166-1 code. Default is US</param>     
        /// <returns></returns>
        Task<MovieList> GetPopularAsync(string language = "en", int page = 1, string region = "US");
        /// <summary>
        /// Get the top rated movies on TMDb.
        ///  /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>       
        /// <param name="language">Default is English</param>
        /// <param name="page">Default is 1</param>
        /// <param name="region">ISO 3166-1 code. Default is US</param>     
        /// <returns></returns>
        Task<MovieList> GetTopRatedAsync(string language = "en", int page = 1, string region = "US");
        /// <summary>
        /// Get a list of upcoming movies in theatres. This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>        
        /// <param name="language">Default is English</param>
        /// <param name="page">Default is 1</param>
        /// <param name="region"></param>     
        /// <returns>ISO 3166-1 code. Default is US</returns>
        Task<DatedMovieList> GetUpcomingAsync(string language = "en", int page = 1, string region = "US");
    }
}
