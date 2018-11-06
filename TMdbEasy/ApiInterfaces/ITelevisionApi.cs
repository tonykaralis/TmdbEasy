using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.TmdbObjects.TV;
using TMdbEasy.TmdbObjects.Images;
using TMdbEasy.TmdbObjects.Movies;
using TMdbEasy.TmdbObjects.Changes;
using TMdbEasy.TmdbObjects.Other;
using TMdbEasy.TmdbObjects.Language;
using TMdbEasy.TmdbObjects.Certifications;

namespace TMdbEasy.ApiInterfaces
{
    public interface ITelevisionApi : IBase
    {
        /// <summary>
        /// Gets all the information about a specific TV show.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<Tv> GetDetailsAsync(int id, string language = "en");
        /// <summary>
        /// Returns all images that belong to a TV show.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<Images> GetImagesAsync(int id, string language = "en");
        /// <summary>
        /// Returns the list of content ratings (certifications) that have been added to a TV show.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<TvRatingList> GetContentRatingsAsync(int id, string language = "en");
        /// <summary>
        /// Returns all alternative titles that belong to a TV show.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Default is English</param>
        /// <returns></returns>
        Task<AlternativeTitle> GetAlternativeTitlesAsync(int id, string language = "en");
        /// <summary>
        /// Get the changes for a TV show. By default only the last 24 hours are returned.
        /// You can query up to 14 days in a single query by using the start_date and end_date query parameters.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="start_date"></param>
        /// <param name="end_date"></param>
        /// <param name="page"></param>       
        /// <returns></returns>
        Task<TVChangeList> GetChangesAsync(int id, string start_date, string end_date, int page);
        /// <summary>
        /// Get the cast and crew for a TV show.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>        
        /// <returns></returns>
        Task<MovieCredits> GetCreditsAsync(int id, string language = "en");
        /// <summary>
        /// Get the external ids for a TV show. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>       
        /// <param name="language">Default is English</param>
        /// <returns></returns>
        Task<MovieExternalId> GetExternalIdsAsync(int id, string language = "en");
        /// <summary>
        /// Get the videos that have been added to a TV show.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>        
        /// <param name="language">Default is English</param>
        /// <returns></returns>
        Task<VideoList> GetVideosAsync(int id, string language = "en");
        /// <summary>
        /// Returns all alternative titles that belong to a TV show.
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
        Task<TVShowList> GetRecommendationsAsync(int id, string language = "en", int page = 1);
        /// <summary>
        /// Get a list of similar TV shows. This is not the same as the "Recommendation" system you see on the website.
        /// These items are assembled by looking at keywords and genres.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Default is English</param>
        /// <param name="page">Default is 1</param>     
        /// <returns></returns>
        Task<TVShowList> GetSimilarTVShowsAsync(int id, string language = "en", int page = 1);
        /// <summary>
        /// Get the user reviews for a TV show.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Default is English</param>
        /// <param name="page">Default is 1</param>     
        /// <returns></returns>
        Task<UserReviews> GetUserReviewsAsync(int id, string language = "en", int page = 1);
        /// <summary>
        /// Get the most newly created TV show. This is a live response and will continuously change.
        /// </summary>      
        /// <param name="language">Default is English</param>            
        /// <returns></returns>
        Task<Tv> GetLatestAsync(string language = "en");
        /// <summary>
        /// Get a list of shows that are currently on the air. This query looks for any TV show that has an episode with an air date in the next 7 days.
        /// </summary>       
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <param name="page">Default is 1</param>
        /// <param name="region">ISO 3166-1 code. Default is US</param>     
        /// <returns></returns>
        Task<TVShowList> GetTVOnTheAir(string language = "en", int page = 1);
        /// <summary>
        /// Get a list of shows that are currently on the air. This query looks for any TV show that has an episode with an air date in the next 7 days.
        /// </summary>       
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <param name="page">Default is 1</param>
        /// <returns></returns>
        Task<TVShowList> GetTVAiringToday(string language = "en", int page = 1);
        /// <summary>
        /// Get a list of the current popular movies on TMDb. This list updates daily.
        /// </summary>       
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <param name="page">Default is 1</param>
        /// <returns></returns>
        Task<TVShowList> GetPopularAsync(string language = "en", int page = 1);
        /// <summary>
        /// Get a list of the top rated TV shows on TMDb.
        /// </summary>       
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <param name="page">Default is 1</param>
        /// <returns></returns>
        Task<TVShowList> GetTopRatedAsync(string language = "en", int page = 1);
        /// <summary>
        /// Get the TV season details by id.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<TvSeason> GetSeasonDetailsAsync(int id, int seasonNumber, string language = "en");
        /// <summary>
        /// Get the credits for TV season.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<MovieCredits> GetSeasonCreditsAsync(int id, int seasonNumber, string language = "en");
        /// <summary>
        /// Get the external ids for a TV season. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>       
        /// <param name="seasonNumber">The season number.</param>
        /// <returns></returns>
        Task<MovieExternalId> GetSeasonExternalIdsAsync(int id, int seasonNumber);
        /// <summary>
        /// Returns all images that belong to a TV season.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<Images> GetSeasonImagesAsync(int id, int seasonNumber, string language = "en");
        /// <summary>
        /// Returns all videos that belong to a TV season.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<VideoList> GetSeasonVideosAsync(int id, int seasonNumber, string language = "en");
        /// <summary>
        /// Returns the TV episode details by id.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<Episode> GetEpisodeDetailsAsync(int id, int seasonNumber, int episodeNumber, string language = "en");
        /// <summary>
        /// Returns the TV episode details by id.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <returns></returns>
        Task<MovieCredits> GetEpisodeCreditsAsync(int id, int seasonNumber, int episodeNumber);
        /// <summary>
        /// Get the external ids for a TV episode. Support for facebook, instagram, twitter and IMDB.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <returns></returns>
        Task<MovieExternalId> GetEpisodeExternalIdsAsync(int id, int seasonNumber, int episodeNumber);
        /// <summary>
        /// Returns all images that belong to a TV episode.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <returns></returns>
        Task<Images> GetEpisodeImagesAsync(int id, int seasonNumber, int episodeNumber);
        /// <summary>
        /// Returns the translation data for an episode.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <returns></returns>
        Task<TranslationsList> GetEpisodeTranslationsAsync(int id, int seasonNumber, int episodeNumber);
        /// <summary>
        /// Returns all the videos that have been added to a TV episode.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<VideoList> GetSeasonVideosAsync(int id, int seasonNumber, int episodeNumber, string language = "en");
        /// <summary>
        /// Search for a TV show.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="language">The language.</param>
        /// <param name="page">Defaults to 1</param>
        /// <param name="first_air_date_year">The first air date year.</param>
        /// <returns></returns>
        Task<TVShowList> SearchTVShowsAsync(string query, string language = "en", int page = 1, int first_air_date_year = 0);
    }
}
