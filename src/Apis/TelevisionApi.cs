using System.Threading.Tasks;
using TmdbEasy.DTO.Certifications;
using TmdbEasy.DTO.Changes;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Language;
using TmdbEasy.DTO.Movies;
using TmdbEasy.DTO.Other;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.DTO.Television;
using TmdbEasy.DTO.TV;
using TmdbEasy.Extensions;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class TelevisionApi : ITelevisionApi
    {
        private readonly IRequestHandler _requestHandler;
        private readonly ITmdbEasyClient _client;

        public TelevisionApi(ITmdbEasyClient client)
        {
            _client = client;
            _requestHandler = new RequestHandler(_client);
        }

        public async Task<Tv> GetDetailsAsync(string tvId, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment("tv")
                .AddUrlSegment($"{tvId}")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<Tv>(restRequest);
        }

        public async Task<TvRatingList> GetContentRatingsAsync(string tvId, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment("tv")
                .AddUrlSegment($"{tvId}")
                .AddUrlSegment("content_ratings")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TvRatingList>(restRequest);
        }

        public async Task<Images> GetImagesAsync(string tvId, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment("tv")
                .AddUrlSegment($"{tvId}")
                .AddUrlSegment("images")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<Images>(restRequest);
        }

        public async Task<AlternativeTitle> GetAlternativeTitlesAsync(string tvId, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment("tv")
                .AddUrlSegment($"{tvId}")
                .AddUrlSegment("alternative_titles")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<AlternativeTitle>(restRequest);
        }
        //not tested
        public async Task<ChangeList> GetChangesAsync(int tvId, string start_date = null, string end_date = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment("tv")
                .AddUrlSegment($"{tvId}")
                .AddUrlSegment("changes")
                .AddPage(page)
                .AddStartDate(start_date)
                .AddEndDate(end_date)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<ChangeList>(restRequest);
        }
        //not tested
        public async Task<MovieCredits> GetCreditsAsync(string tvId, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("tv")
               .AddUrlSegment($"{tvId}")
               .AddUrlSegment("credits")
               .AddLanguage(language)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieCredits>(restRequest);
        }

        public async Task<MovieExternalId> GetExternalIdsAsync(string tvId, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("tv")
               .AddUrlSegment($"{tvId}")
               .AddUrlSegment("external_ids")
               .AddLanguage(language)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieExternalId>(restRequest);
        }
        //not tested
        public async Task<VideoList> GetVideosAsync(string tvId, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
              .CreateRequest()
              .AddUrlSegment("tv")
              .AddUrlSegment($"{tvId}")
              .AddUrlSegment("videos")
              .AddLanguage(language)
              .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<VideoList>(restRequest);
        }
        //not tested
        public async Task<TranslationList> GetTranslationsAsync(string tvId, string apiKey = null)
        {
            var restRequest = _requestHandler
              .CreateRequest()
              .AddUrlSegment("tv")
              .AddUrlSegment($"{tvId}")
              .AddUrlSegment("translations")
              .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TranslationList>(restRequest);
        }
        //not tested
        public async Task<TvShowList> GetRecommendationsAsync(string tvId, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("tv")
               .AddUrlSegment($"{tvId}")
               .AddUrlSegment("recommendations")
               .AddLanguage(language)
               .AddPage(page)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TvShowList>(restRequest);
        }
        //not tested
        public async Task<TvShowList> GetSimilarTVShowsAsync(string tvId, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
              .CreateRequest()
              .AddUrlSegment("tv")
              .AddUrlSegment($"{tvId}")
              .AddUrlSegment("similar")
              .AddLanguage(language)
              .AddPage(page)
              .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TvShowList>(restRequest);
        }
        //not tested
        public async Task<UserReview> GetUserReviewsAsync(string tvId, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
              .CreateRequest()
              .AddUrlSegment("tv")
              .AddUrlSegment($"{tvId}")
              .AddUrlSegment("reviews")
              .AddLanguage(language)
              .AddPage(page)
              .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<UserReview>(restRequest);
        }
        //not tested
        public async Task<Tv> GetLatestAsync(string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("tv")
               .AddUrlSegment("latest")
               .AddLanguage(language)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<Tv>(restRequest);
        }
        //not tested
        public async Task<TvShowList> GetTVOnTheAir(string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("tv")
               .AddUrlSegment("on_the_air")
               .AddLanguage(language)
               .AddPage(page)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TvShowList>(restRequest);
        }
        //not tested
        public async Task<TvShowList> GetTVAiringToday(string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
              .CreateRequest()
              .AddUrlSegment("tv")
              .AddUrlSegment("airing_today")
              .AddLanguage(language)
              .AddPage(page)
              .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TvShowList>(restRequest);
        }
        //not tested
        public async Task<TvShowList> GetPopularAsync(string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
              .CreateRequest()
              .AddUrlSegment("tv")
              .AddUrlSegment("popular")
              .AddLanguage(language)
              .AddPage(page)
              .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TvShowList>(restRequest);
        }
        //not tested
        public async Task<TvShowList> GetTopRatedAsync(string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
              .CreateRequest()
              .AddUrlSegment("tv")
              .AddUrlSegment("top_rated")
              .AddLanguage(language)
              .AddPage(page)
              .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TvShowList>(restRequest);
        }
        //not tested
        public async Task<TvSeason> GetSeasonDetailsAsync(int tvId, int seasonNumber, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment($"tv/{tvId}")
               .AddUrlSegment($"season/{seasonNumber}")
               .AddLanguage(language)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TvSeason>(restRequest);

        }
        //not tested
        public async Task<MovieCredits> GetSeasonCreditsAsync(int tvId, int seasonNumber, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment($"tv/{tvId}")
               .AddUrlSegment($"season/{seasonNumber}")
               .AddUrlSegment("credits")
               .AddLanguage(language)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieCredits>(restRequest);

        }
        //not tested
        public async Task<MovieExternalId> GetSeasonExternalIdsAsync(int tvId, int seasonNumber, string apiKey = null)
        {
            var restRequest = _requestHandler
              .CreateRequest()
              .AddUrlSegment($"tv/{tvId}")
              .AddUrlSegment($"season/{seasonNumber}")
              .AddUrlSegment("external_ids")
              .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieExternalId>(restRequest);
        }
        //not tested
        public async Task<Images> GetSeasonImagesAsync(int tvId, int seasonNumber, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
            .CreateRequest()
            .AddUrlSegment($"tv/{tvId}")
            .AddUrlSegment($"season/{seasonNumber}")
            .AddUrlSegment($"images")
            .AddLanguage(language)
            .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<Images>(restRequest);
        }
        //not tested
        public async Task<VideoList> GetSeasonVideosAsync(int tvId, int seasonNumber, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"tv/{tvId}")
                .AddUrlSegment($"season/{seasonNumber}")
                .AddUrlSegment($"videos")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<VideoList>(restRequest);
        }

        public async Task<Episode> GetEpisodeDetailsAsync(int tvId, int seasonNumber, int episodeNumber, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"tv/{tvId}")
                .AddUrlSegment($"season/{seasonNumber}")
                .AddUrlSegment($"episode/{episodeNumber}")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<Episode>(restRequest);
        }
        //not tested
        public async Task<MovieCredits> GetEpisodeCreditsAsync(int tvId, int seasonNumber, int episodeNumber, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"tv/{tvId}")
                .AddUrlSegment($"season/{seasonNumber}")
                .AddUrlSegment($"episode/{episodeNumber}")
                .AddUrlSegment($"credits")
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieCredits>(restRequest);
        }
        //not tested
        public async Task<MovieExternalId> GetEpisodeExternalIdsAsync(int tvId, int seasonNumber, int episodeNumber, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"tv/{tvId}")
                .AddUrlSegment($"season/{seasonNumber}")
                .AddUrlSegment($"episode/{episodeNumber}")
                .AddUrlSegment("external_ids")
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieExternalId>(restRequest);
        }
        //not tested
        public async Task<Images> GetEpisodeImagesAsync(int tvId, int seasonNumber, int episodeNumber, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"tv/{tvId}")
                .AddUrlSegment($"season/{seasonNumber}")
                .AddUrlSegment($"episode/{episodeNumber}")
                .AddUrlSegment("images")
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<Images>(restRequest);
        }

        public async Task<TranslationList> GetEpisodeTranslationsAsync(int tvId, int seasonNumber, int episodeNumber, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"tv/{tvId}")
                .AddUrlSegment($"season/{seasonNumber}")
                .AddUrlSegment($"episode/{episodeNumber}")
                .AddUrlSegment($"translations")
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TranslationList>(restRequest);
        }
        //not tested
        public async Task<VideoList> GetSeasonVideosAsync(int tvId, int seasonNumber, int episodeNumber, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"tv/{tvId}")
                .AddUrlSegment($"season/{seasonNumber}")
                .AddUrlSegment($"episode/{episodeNumber}")
                .AddUrlSegment($"videos")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<VideoList>(restRequest);
        }

        public async Task<TvShowList> SearchTVShowsAsync(string query, string language = null, int page = 1, int first_air_date_year = 0, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment("search")
                .AddUrlSegment("tv")
                .AddLanguage(language)
                .AddCustomQuery(query)
                .AddFirstAirDateYear(first_air_date_year)
                .AddPage(page)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TvShowList>(restRequest);
        }
    }
}
