using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects.Images;
using TMdbEasy.TmdbObjects.Movies;

namespace TMdbEasy.ApiObjects
{
    internal class MovieApi : IMovieApi
    {
        public async Task<MovieDetails> GetDetailsAsync(int id, string language = "en")
        {
            //TBD buid string externally
            string query = $"{REngine.Url}movie/{id}?api_key={REngine.ApiKey}&language={language}";
            var content = await REngine.CallApiAsync(query);
            var movie = REngine.DeserializeJson<MovieDetails>(content);
            return movie;
        }

        public async Task<Images> GetImagesAsync(int id, string language = "en")
        {
            string query = $"{REngine.Url}movie/{id}?api_key={REngine.ApiKey}&language={language}";
            var content = await REngine.CallApiAsync(query);
            var movie = REngine.DeserializeJson<Images>(content);
            return movie;
        }

        public async Task<AlternativeTitle> GetAlternativeTitlesAsync(int id, string country = "en")
        {
            //TBD buid string externally
            string query = $"{REngine.Url}movie/{id}/alternative_titles?api_key={REngine.ApiKey}&language={country}";
            var content = await REngine.CallApiAsync(query);
            var titles = REngine.DeserializeJson<AlternativeTitle>(content);
            return titles;
        }

        public MovieApi() { }
    }
}
