using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects.Images;
using TMdbEasy.TmdbObjects.Movies;
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
    }
}
