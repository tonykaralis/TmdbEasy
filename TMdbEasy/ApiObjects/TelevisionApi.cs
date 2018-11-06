using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects.Changes;
using TMdbEasy.TmdbObjects.Images;
using TMdbEasy.TmdbObjects.Language;
using TMdbEasy.TmdbObjects.Movies;
using TMdbEasy.TmdbObjects.Other;
using TMdbEasy.TmdbObjects.TV;
using TMdbEasy.TmdbObjects.Certifications;
using static TMdbEasy.REngine;


namespace TMdbEasy.ApiObjects
{
    sealed class TelevisionApi : ITelevisionApi
    {
        public async Task<Tv> GetDetailsAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<Tv>(content);
        }

        public async Task<TvRatingList> GetContentRatingsAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/content_ratings?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<TvRatingList>(content);
        }

        public async Task<Images> GetImagesAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/images?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<Images>(content);
        }

        public async Task<AlternativeTitle> GetAlternativeTitlesAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/alternative_titles?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<AlternativeTitle>(content);
        }
        //not tested
        public async Task<TVChangeList> GetChangesAsync(int id, string start_date, string end_date, int page)
        {
            string query = $"{Url}tv/{id}/changes?api_key={ApiKey}";
            query.BuildDates(start_date, end_date);
            query += $"&page={page}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            return DeserializeJson<TVChangeList>(content);
        }
        //not tested
        public async Task<MovieCredits> GetCreditsAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/credits?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<MovieCredits>(content);
        }

        public async Task<MovieExternalId> GetExternalIdsAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/external_ids?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<MovieExternalId>(content);
        }
        //not tested
        public async Task<VideoList> GetVideosAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/videos?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<VideoList>(content);
        }
        //not tested
        public async Task<TranslationsList> GetTranslationsAsync(int id)
        {
            var content = await CallApiAsync($"{Url}tv/{id}/translations?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<TranslationsList>(content);
        }
        //not tested
        public async Task<TVShowList> GetRecommendationsAsync(int id, string language = "en", int page = 1)
        {
            var content = await CallApiAsync($"{Url}tv/{id}/recommendations?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
            return DeserializeJson<TVShowList>(content);
        }
        //not tested
        public async Task<TVShowList> GetSimilarTVShowsAsync(int id, string language = "en", int page = 1)
        {
            var content = await CallApiAsync($"{Url}tv/{id}/similar?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
            return DeserializeJson<TVShowList>(content);
        }
        //not tested
        public async Task<UserReviews> GetUserReviewsAsync(int id, string language = "en", int page = 1)
        {
            var content = await CallApiAsync($"{Url}tv/{id}/reviews?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
            return DeserializeJson<UserReviews>(content);
        }
        //not tested
        public async Task<Tv> GetLatestAsync(string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/latest?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<Tv>(content);
        }

        public async Task<TVShowList> GetTVOnTheAir(string language = "en", int page = 1)
        {
            var content = await CallApiAsync($"{Url}tv/on_the_air?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
            return DeserializeJson<TVShowList>(content);
        }

        public async Task<TVShowList> GetTVAiringToday(string language = "en", int page = 1)
        {
            var content = await CallApiAsync($"{Url}tv/airing_today?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
            return DeserializeJson<TVShowList>(content);
        }

        public async Task<TVShowList> GetPopularAsync(string language = "en", int page = 1)
        {
            var content = await CallApiAsync($"{Url}tv/popular?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
            return DeserializeJson<TVShowList>(content);
        }
        //not tested
        public async Task<TVShowList> GetTopRatedAsync(string language = "en", int page = 1)
        {
            var content = await CallApiAsync($"{Url}tv/top_rated?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
            return DeserializeJson<TVShowList>(content);
        }

        public async Task<TvSeason> GetSeasonDetailsAsync(int id, int seasonNumber, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/season/{seasonNumber}?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<TvSeason>(content);
        }
        //not tested
        public async Task<MovieCredits> GetSeasonCreditsAsync(int id, int seasonNumber, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/season/{seasonNumber}/credits?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<MovieCredits>(content);
        }
        //not tested
        public async Task<MovieExternalId> GetSeasonExternalIdsAsync(int id, int seasonNumber)
        {
            var content = await CallApiAsync($"{Url}tv/{id}/season/{seasonNumber}/external_ids?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<MovieExternalId>(content);
        }

        public async Task<Images> GetSeasonImagesAsync(int id, int seasonNumber, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/season/{seasonNumber}/images?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<Images>(content);
        }
        //not tested
        public async Task<VideoList> GetSeasonVideosAsync(int id, int seasonNumber, string language = "en")
        {
            var content = await CallApiAsync($"{Url}tv/{id}/season/{seasonNumber}/videos?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<VideoList>(content);
        }

        public async Task<Episode> GetEpisodeDetailsAsync(int id, int seasonNumber, int episodeNumber, string language = "en")
        {
            string query = $"{Url}tv/{id}/season/{seasonNumber}/episode/{episodeNumber}?api_key={ApiKey}&language={language}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            return DeserializeJson<Episode>(content);
        }
        //not tested
        public async Task<MovieCredits> GetEpisodeCreditsAsync(int id, int seasonNumber, int episodeNumber)
        {
            string query = $"{Url}tv/{id}/season/{seasonNumber}/episode/{episodeNumber}/credits?api_key={ApiKey}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            return DeserializeJson<MovieCredits>(content);
        }
        //not tested
        public async Task<MovieExternalId> GetEpisodeExternalIdsAsync(int id, int seasonNumber, int episodeNumber)
        {
            string query = $"{Url}tv/{id}/season/{seasonNumber}/episode/{episodeNumber}/external_ids?api_key={ApiKey}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            return DeserializeJson<MovieExternalId>(content);
        }
        //not tested
        public async Task<Images> GetEpisodeImagesAsync(int id, int seasonNumber, int episodeNumber)
        {
            string query = $"{Url}tv/{id}/season/{seasonNumber}/episode/{episodeNumber}/images?api_key={ApiKey}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            return DeserializeJson<Images>(content);
        }

        public async Task<TranslationsList> GetEpisodeTranslationsAsync(int id, int seasonNumber, int episodeNumber)
        {
            string query = $"{Url}tv/{id}/season/{seasonNumber}/episode/{episodeNumber}/translations?api_key={ApiKey}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            return DeserializeJson<TranslationsList>(content);
        }
        //not tested
        public async Task<VideoList> GetSeasonVideosAsync(int id, int seasonNumber, int episodeNumber, string language = "en")
        {
            string query = $"{Url}tv/{id}/season/{seasonNumber}/episode/{episodeNumber}/videos?api_key={ApiKey}&language={language}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            return DeserializeJson<VideoList>(content);
        }

        public async Task<TVShowList> SearchTVShowsAsync(string query, string language = "en", int page = 1, int first_air_date_year = 0)
        {
            var content = await CallApiAsync($"{Url}search/tv?api_key={ApiKey}&language={language}&query={query}" +
                $"&page={page}").ConfigureAwait(false);
            if (first_air_date_year > 0)
            {
                content += $"&first_air_date_year={first_air_date_year}";
            }

            return DeserializeJson<TVShowList>(content);
        }
    }
}
