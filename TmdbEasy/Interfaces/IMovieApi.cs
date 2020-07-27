using System.Threading.Tasks;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Changes;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Language;
using TmdbEasy.DTO.Movies;
using TmdbEasy.DTO.Other;
using TmdbEasy.DTO.Reviews;

namespace TmdbEasy.Interfaces
{
    public interface IMovieApi : IBaseApi
    {
        /// <summary>
        /// Gets all the information about a specific movie.
        /// </summary>
        Task<MovieFullDetails> GetDetailsAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Returns all movies that belong to a movie.
        /// </summary>
        Task<Images> GetImagesAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Returns all alternative titles that belong to a movie.
        /// </summary>
        Task<AlternativeTitle> GetAlternativeTitlesAsync(IdCountryRequest request);
        /// <summary>
        /// Get the changes for a movie. By default only the last 24 hours are returned.
        /// You can query up to 14 days in a single query by using the start_date and end_date query parameters.
        /// </summary>
        Task<MovieChangeList> GetChangesAsync(PagedIdDateRequest request);
        /// <summary>
        /// Get the cast and crew for a movie.
        /// </summary>
        Task<MovieCredits> GetCreditsAsync(IdRequest request);
        /// <summary>
        /// Get the external ids for a movie. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        Task<MovieExternalId> GetExternalIdsAsync(IdRequest request);
        /// <summary>
        /// Get the release date along with the certification for a movie.
        /// </summary>
        Task<MovieReleaseDateList> GetReleaseDatesAsync(IdRequest request);
        /// <summary>
        /// Get the videos that have been added to a movie.
        /// </summary>
        Task<VideoList> GetVideosAsync(IdRequest request);
        /// <summary>
        /// Returns all alternative titles that belong to a movie.
        /// </summary>
        Task<TranslationList> GetTranslationsAsync(IdRequest request);
        /// <summary>
        /// Get a list of recommended movies for a movie.
        /// </summary>
        Task<MovieList> GetRecommendationsAsync(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get a list of similar movies. This is not the same as the "Recommendation" system you see on the website.
        /// These items are assembled by looking at keywords and genres.
        /// </summary>
        Task<MovieList> GetSimilarMoviesAsync(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get the user reviews for a movie.
        /// </summary>
        Task<UserReview> GetUserReviewsAsync(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get the most newly created movie. This is a live response and will continuously change.
        /// </summary>      
        Task<MovieFullDetails> GetLatestAsync(string userApiKey = null, string language = "en");
        /// <summary>
        /// Get a list of movies in theatres. This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>       
        Task<DatedMovieList> GetNowPlayingAsync(PagedLanguageRegionRequest request);
        /// <summary>
        /// Get a list of the current popular movies on TMDb. This list updates daily.
        ///  /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>       
        Task<MovieList> GetPopularAsync(PagedLanguageRegionRequest request);
        /// <summary>
        /// Get the top rated movies on TMDb.
        ///  /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>       
        Task<MovieList> GetTopRatedAsync(PagedLanguageRegionRequest request);
        /// <summary>
        /// Get a list of upcoming movies in theatres. This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>        
        Task<DatedMovieList> GetUpcomingAsync(PagedLanguageRegionRequest request);
        /// <summary>
        /// Search for movies.
        /// </summary>
        Task<MovieList> SearchMoviesAsync(MovieSearchRequest request);
        /// <summary>
        /// Search for movies by actors.
        /// </summary>
        Task<MovieList> SearchByActorAsync(SearchByActorRequest request);
    }
}
