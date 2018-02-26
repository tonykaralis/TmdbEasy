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
    internal class MovieApi : IMovieApi
    {
        public async Task<MovieDetails> GetDetailsAsync(int id, string language = "en")
        {
            string query = $"{Url}movie/{id}?api_key={ApiKey}&language={language}";
            var content = await CallApiAsync(query);
            var movie = DeserializeJson<MovieDetails>(content);
            return movie;
        }

        public async Task<Images> GetImagesAsync(int id, string language = "en")
        {
            string query = $"{Url}movie/{id}?api_key={ApiKey}&language={language}";
            var content = await CallApiAsync(query);
            var movie = DeserializeJson<Images>(content);
            return movie;
        }

        public async Task<AlternativeTitle> GetAlternativeTitlesAsync(int id, string country = "en")
        {
            //TBD buid string externally
            string query = $"{Url}movie/{id}/alternative_titles?api_key={ApiKey}&language={country}";
            var content = await CallApiAsync(query);
            var titles = DeserializeJson<AlternativeTitle>(content);
            return titles;
        }

        public MovieApi() { }
    }
}
