using System.Threading.Tasks;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Certifications;
using TmdbEasy.DTO.Changes;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Language;
using TmdbEasy.DTO.Movies;
using TmdbEasy.DTO.Other;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.DTO.Television;
using TmdbEasy.DTO.TV;

namespace TmdbEasy.Interfaces
{
    public interface ITelevisionApi : IBaseApi
    {
        /// <summary>
        /// Gets all the information about a specific TV show.
        /// </summary>
        Task<Tv> GetDetailsAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Returns all images that belong to a TV show.
        /// </summary>
        Task<Images> GetImagesAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Returns the list of content ratings (certifications) that have been added to a TV show.
        /// </summary>
        Task<TvRatingList> GetContentRatingsAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Returns all alternative titles that belong to a TV show.
        /// </summary>
        Task<AlternativeTitle> GetAlternativeTitlesAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Get the changes for a TV show. By default only the last 24 hours are returned.
        /// You can query up to 14 days in a single query by using the start_date and end_date query parameters.
        /// </summary>
        Task<ChangeList> GetChangesAsync(int id, string start_date, string end_date, int page);
        /// <summary>
        /// Get the cast and crew for a TV show.
        /// </summary>
        Task<MovieCredits> GetCreditsAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Get the external ids for a TV show. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        Task<MovieExternalId> GetExternalIdsAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Get the videos that have been added to a TV show.
        /// </summary>
        Task<VideoList> GetVideosAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Returns all alternative titles that belong to a TV show.
        /// </summary>
        Task<TranslationList> GetTranslationsAsync(IdRequest request);
        /// <summary>
        /// Get a list of recommended movies for a movie.
        /// </summary>
        Task<TvShowList> GetRecommendationsAsync(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get a list of similar TV shows. This is not the same as the "Recommendation" system you see on the website.
        /// These items are assembled by looking at keywords and genres.
        /// </summary>
        Task<TvShowList> GetSimilarTVShowsAsync(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get the user reviews for a TV show.
        /// </summary>
        Task<UserReview> GetUserReviewsAsync(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get the most newly created TV show. This is a live response and will continuously change.
        /// </summary>      
        Task<Tv> GetLatestAsync(string userApikey, string language = "en");
        /// <summary>
        /// Get a list of shows that are currently on the air. This query looks for any TV show that has an episode with an air date in the next 7 days.
        /// </summary>       
        Task<TvShowList> GetTVOnTheAir(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get a list of shows that are currently on the air. This query looks for any TV show that has an episode with an air date in the next 7 days.
        /// </summary>       
        Task<TvShowList> GetTVAiringToday(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get a list of the current popular movies on TMDb. This list updates daily.
        /// </summary>       >
        Task<TvShowList> GetPopularAsync(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get a list of the top rated TV shows on TMDb.
        /// </summary>       
        Task<TvShowList> GetTopRatedAsync(PagedIdRequest request, string language = "en");
        /// <summary>
        /// Get the TV season details by id.
        /// </summary>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        Task<TvSeason> GetSeasonDetailsAsync(SeasonRequest request, string language = "en");
        /// <summary>
        /// Get the credits for TV season.
        /// </summary>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        Task<MovieCredits> GetSeasonCreditsAsync(SeasonRequest request, string language = "en");
        /// <summary>
        /// Get the external ids for a TV season. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        Task<MovieExternalId> GetSeasonExternalIdsAsync(SeasonRequest request);
        /// <summary>
        /// Returns all images that belong to a TV season.
        /// </summary>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        Task<Images> GetSeasonImagesAsync(SeasonRequest request, string language = "en");
        /// <summary>
        /// Returns all videos that belong to a TV season.
        /// </summary>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        Task<VideoList> GetSeasonVideosAsync(SeasonRequest request, string language = "en");
        /// <summary>
        /// Returns the TV episode details by id.
        /// </summary>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        Task<Episode> GetEpisodeDetailsAsync(SeasonEpisodeRequest request, string language = "en");
        /// <summary>
        /// Returns the TV episode details by id.
        /// </summary>
        Task<MovieCredits> GetEpisodeCreditsAsync(SeasonEpisodeRequest request);
        /// <summary>
        /// Get the external ids for a TV episode. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        Task<MovieExternalId> GetEpisodeExternalIdsAsync(SeasonEpisodeRequest request);
        /// <summary>
        /// Returns all images that belong to a TV episode.
        /// </summary>
        Task<Images> GetEpisodeImagesAsync(SeasonEpisodeRequest request);
        /// <summary>
        /// Returns the translation data for an episode.
        /// </summary>
        Task<TranslationList> GetEpisodeTranslationsAsync(SeasonEpisodeRequest request);
        /// <summary>
        /// Returns all the videos that have been added to a TV episode.
        /// </summary>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        Task<VideoList> GetSeasonVideosAsync(SeasonEpisodeRequest request, string language = "en");
        /// <summary>
        /// Search for a TV show.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="language">The language.</param>
        /// <param name="page">Defaults to 1</param>
        /// <param name="first_air_date_year">The first air date year.</param>
        /// <returns></returns>
        Task<TvShowList> SearchTVShowsAsync(string query, string language = "en", int page = 1, int first_air_date_year = 0);
    }
}
