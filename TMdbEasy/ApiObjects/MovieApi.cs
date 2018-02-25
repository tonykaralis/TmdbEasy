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
        public async Task<MovieDetails> GetDetailsAsync(int movieId, string language = "en")
        {
            //TBD buid string externally
            string query = $"{REngine.Url}3/movie/{movieId}?api_key={REngine.ApiKey}&language={language}";
            var content = await REngine.CallApiAsync(query);
            var movie = REngine.DeserializeJson<MovieDetails>(content);
            return movie;
        }

        public async Task<Images> GetImagesAsync(int movieId, string language = "en")
        {
            string query = $"{REngine.Url}3/movie/{movieId}?api_key={REngine.ApiKey}&language={language}";
            var content = await REngine.CallApiAsync(query);
            var movie = REngine.DeserializeJson<Images>(content);
            return movie;
        }

        public MovieApi() { }
    }
}
