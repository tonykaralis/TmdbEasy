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
    public interface ITelevisionApi
    {
        /// <summary>
        /// Gets all the information about a specific TV show.
        /// </summary>
        /// <param name="reviewId"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<Tv> GetDetailsAsync(string tvId, string language = null, string apiKey = null);
        /// <summary>
        /// Returns all images that belong to a TV show.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<Images> GetImagesAsync(string tvId, string language = null, string apiKey = null);
        /// <summary>
        /// Returns the list of content ratings (certifications) that have been added to a TV show.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TvRatingList> GetContentRatingsAsync(string tvId, string language = null, string apiKey = null);
        /// <summary>
        /// Returns all alternative titles that belong to a TV show.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<AlternativeTitle> GetAlternativeTitlesAsync(string tvId, string language = null, string apiKey = null);
        /// <summary>
        /// Get the changes for a TV show. By default only the last 24 hours are returned.
        /// You can query up to 14 days in a single query by using the start_date and end_date query parameters.
        /// </summary>
        /// <param name="tvid"></param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<ChangeList> GetChangesAsync(int tvid, string start_date = null, string end_date = null, int page = 1, string apiKey = null);
        /// <summary>
        /// Get the cast and crew for a TV show.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieCredits> GetCreditsAsync(string tvId, string language = "en", string apiKey = null);
        /// <summary>
        /// Get the external ids for a TV show. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieExternalId> GetExternalIdsAsync(string tvId, string language = "en", string apiKey = null);
        /// <summary>
        /// Get the videos that have been added to a TV show.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<VideoList> GetVideosAsync(string tvId, string language = "en", string apiKey = null);
        /// <summary>
        /// Returns all translations that belong to a TV show.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TranslationList> GetTranslationsAsync(string tvId, string apiKey = null);
        /// <summary>
        /// Get a list of recommended movies for a movie.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TvShowList> GetRecommendationsAsync(string tvId, string language = "en", int page = 1, string apiKey = null);
        /// <summary>
        /// Get a list of similar TV shows. This is not the same as the "Recommendation" system you see on the website.
        /// These items are assembled by looking at keywords and genres.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TvShowList> GetSimilarTVShowsAsync(string tvId, string language = "en", int page = 1, string apiKey = null);
        /// <summary>
        /// Get the user reviews for a TV show.
        /// </summary>
        /// <param name="tvId"></param>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<UserReview> GetUserReviewsAsync(string tvId, string language = "en", int page = 1, string apiKey = null);
        /// <summary>
        /// Get the most newly created TV show. This is a live response and will continuously change.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>        
        Task<Tv> GetLatestAsync(string language = "en", string apiKey = null);
        /// <summary>
        /// Get a list of shows that are currently on the air. This query looks for any TV show that has an episode with an air date in the next 7 days.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>        
        Task<TvShowList> GetTVOnTheAir(string language = "en", int page = 1, string apiKey = null);
        /// <summary>
        /// Get a list of shows that are currently on the air. This query looks for any TV show that has an episode with an air date in the next 7 days.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TvShowList> GetTVAiringToday(string language = "en", int page = 1, string apiKey = null);
        /// <summary>
        /// Get a list of the current popular movies on TMDb. This list updates daily.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TvShowList> GetPopularAsync(string language = "en", int page = 1, string apiKey = null);
        /// <summary>
        /// Get a list of the top rated TV shows on TMDb.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>        
        Task<TvShowList> GetTopRatedAsync(string language = "en", int page = 1, string apiKey = null);
        /// <summary>
        /// Get the TV season details by id.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TvSeason> GetSeasonDetailsAsync(int seasonId, int seasonNumber, string language = "en", string apiKey = null);
        /// <summary>
        /// Get the credits for TV season.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieCredits> GetSeasonCreditsAsync(int seasonId, int seasonNumber, string language = "en", string apiKey = null);
        /// <summary>
        /// Get the external ids for a TV season. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieExternalId> GetSeasonExternalIdsAsync(int seasonId, int seasonNumber, string apiKey = null);
        /// <summary>
        /// Returns all images that belong to a TV season.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<Images> GetSeasonImagesAsync(int seasonId, int seasonNumber, string language = "en", string apiKey = null);
        /// <summary>
        /// Returns all videos that belong to a TV season.
        /// </summary>
        /// <param name="seasonId"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<VideoList> GetSeasonVideosAsync(int seasonId, int seasonNumber, string language = "en", string apiKey = null);
        /// <summary>
        /// Returns the TV episode details by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="episodeNumber"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<Episode> GetEpisodeDetailsAsync(int id, int seasonNumber, int episodeNumber, string language = "en", string apiKey = null);
        /// <summary>
        /// Returns the TV episode details by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieCredits> GetEpisodeCreditsAsync(int id, int seasonNumber, string apiKey = null);
        /// <summary>
        /// Get the external ids for a TV episode. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<MovieExternalId> GetEpisodeExternalIdsAsync(int id, int seasonNumber, string apiKey = null);
        /// <summary>
        /// Returns all images that belong to a TV episode.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<Images> GetEpisodeImagesAsync(int id, int seasonNumber, string apiKey = null);
        /// <summary>
        /// Returns the translation data for an episode.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TranslationList> GetEpisodeTranslationsAsync(int id, int seasonNumber, string apiKey = null);
        /// <summary>
        /// Returns all the videos that have been added to a TV episode.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="seasonNumber"></param>
        /// <param name="episodeNumber"></param>
        /// <param name="language"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<VideoList> GetSeasonVideosAsync(int id, int seasonNumber, int episodeNumber, string language = "en", string apiKey = null);
        /// <summary>
        /// Search for a TV show.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="language">The language.</param>
        /// <param name="page">Defaults to 1</param>
        /// <param name="first_air_date_year">The first air date year.</param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<TvShowList> SearchTVShowsAsync(string query, string language = "en", int page = 1, int first_air_date_year = 0, string apiKey = null);
    }
}
