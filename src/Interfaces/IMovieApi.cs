using System.Threading.Tasks;
using TmdbEasy.DTO.Changes;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Language;
using TmdbEasy.DTO.Movies;
using TmdbEasy.DTO.Other;
using TmdbEasy.DTO.Reviews;

namespace TmdbEasy.Interfaces
{
    public interface IMovieApi
    {
        /// <summary>
        /// Gets all the information about a specific movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieFullDetails> GetDetailsAsync(int movieId, string language = null, string apiKey = null);
        /// <summary>       
        /// Returns all movies that belong to a movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<Images> GetImagesAsync(int movieId, string language = null, string apiKey = null);
        /// <summary>
        /// Returns all alternative titles that belong to a movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="country"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<AlternativeTitle> GetAlternativeTitlesAsync(int movieId, string country = null, string apiKey = null);
        /// <summary>
        /// Get the changes for a movie. By default only the last 24 hours are returned.
        /// You can query up to 14 days in a single query by using the start_date and end_date query parameters.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="end_date"></param>
        /// <param name="start_date"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieChangeList> GetChangesAsync(int movieId, string end_date = null, string start_date = null, int page = 1, string apiKey = null);
        /// <summary>
        /// Get the cast and crew for a movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieCredits> GetCreditsAsync(int movieId, string apiKey = null);
        /// <summary>
        /// Get the external ids for a movie. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        Task<MovieExternalId> GetExternalIdsAsync(int movieId, string apiKey = null);
        /// <summary>
        /// Get the release date along with the certification for a movie.
        /// </summary>
        Task<MovieReleaseDateList> GetReleaseDatesAsync(int movieId, string apiKey = null);
        /// <summary>
        /// Get the videos that have been added to a movie.
        /// </summary>
        Task<VideoList> GetVideosAsync(int movieId, string apiKey = null);
        /// <summary>
        /// Returns all alternative titles that belong to a movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TranslationList> GetTranslationsAsync(int movieId, string apiKey = null);
        /// <summary>
        /// Get a list of recommended movies for a movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieList> GetRecommendationsAsync(int movieId, string language = null, int page = 1, string apiKey = null);
        /// <summary>
        /// Get a list of similar movies. This is not the same as the "Recommendation" system you see on the website.
        /// These items are assembled by looking at keywords and genres.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieList> GetSimilarMoviesAsync(int movieId, string language = null, int page = 1, string apiKey = null);
        /// <summary>
        /// Get the user reviews for a movie.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<UserReview> GetUserReviewsAsync(int movieId, string language = null, int page = 1, string apiKey = null);
        /// <summary>
        /// Get the most newly created movie. This is a live response and will continuously change.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieFullDetails> GetLatestAsync(string language = null, string apiKey = null);
        /// <summary>
        /// Get a list of movies in theatres. This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<DatedMovieList> GetNowPlayingAsync(string region = null, string language = null, int page = 1, string apiKey = null);
        /// <summary>
        /// Get a list of the current popular movies on TMDb. This list updates daily.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>        
        Task<MovieList> GetPopularAsync(string region = null, string language = null, int page = 1, string apiKey = null);
        /// <summary>
        /// Get the top rated movies on TMDb.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>        
        Task<MovieList> GetTopRatedAsync(string region = null, string language = null, int page = 1, string apiKey = null);
        /// <summary>
        /// Get a list of upcoming movies in theatres. This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>
        /// <param name="region"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<DatedMovieList> GetUpcomingAsync(string region = null, string language = null, int page = 1, string apiKey = null);
        /// <summary>
        /// Search for movies.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="include_adult"></param>
        /// <param name="region"></param>
        /// <param name="year"></param>
        /// <param name="primary_release_year"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieList> SearchMoviesAsync(string query, string language = null, int page = 1, bool include_adult = false, string region = null, 
            int year = default, int primary_release_year = default, string apiKey = null);
        /// <summary>
        /// Search for movies by actors.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="include_adult"></param>
        /// <param name="region"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieList> SearchByActorAsync(string query, string language = null, int page = 1, bool include_adult = false, string region = null, string apiKey = null);
    }
}
