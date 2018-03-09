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
using static TMdbEasy.REngine;

namespace TMdbEasy.ApiObjects
{
    public sealed class MovieApi : IMovieApi
    {
        public async Task<MovieFullDetails> GetDetailsAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}movie/{id}?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<MovieFullDetails>(content);
        }

        public async Task<Images> GetImagesAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}movie/{id}?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<Images>(content);
        }

        public async Task<AlternativeTitle> GetAlternativeTitlesAsync(int id, string country = "en")
        {
            var content = await CallApiAsync($"{Url}movie/{id}/alternative_titles?api_key={ApiKey}&language={country}").ConfigureAwait(false);
            return DeserializeJson<AlternativeTitle>(content);
        }
        //not tested
        public async Task<MovieChangeList> GetChangesAsync(int id, string start_date, string end_date, int page = 1)
        {
            string query = $"{Url}movie/{id}/changes?api_key={ApiKey}";
            query.BuildDates(start_date, end_date);
            query += $"&page={page}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            return DeserializeJson<MovieChangeList>(content);
        }
        //not tested
        public async Task<MovieCredits> GetCreditsAsync(int id)
        {
            var content = await CallApiAsync($"{Url}movie/{id}/credits?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<MovieCredits>(content);
        }
        //not tested
        public async Task<MovieExternalId> GetExternalIdsAsync(int id)
        {
            var content = await CallApiAsync($"{Url}movie/{id}/external_ids?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<MovieExternalId>(content);
        }
        //not tested
        public async Task<MovieReleaseDateList> GetReleaseDatesAsync(int id)
        {
            var content = await CallApiAsync($"{Url}movie/{id}/release_dates?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<MovieReleaseDateList>(content);
        }
        //not tested
        public async Task<VideoList> GetVideosAsync(int id)
        {
            var content = await CallApiAsync($"{Url}movie/{id}/videos?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<VideoList>(content);
        }
        //not tested
        public async Task<TranslationsList> GetTranslationsAsync(int id)
        {
            var content = await CallApiAsync($"{Url}movie/{id}/translations?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<TranslationsList>(content);
        }
        //not tested
        public async Task<MovieList> GetRecommendationssAsync(int id, string language="en", int page=1)
        {
            var content = await CallApiAsync($"{Url}movie/{id}/recommendations?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
            return DeserializeJson<MovieList>(content);
        }
    }
}
