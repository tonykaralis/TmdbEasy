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
            //TBD buid strign externally
            string query = "https://api.themoviedb.org/3/movie/"+$"{movieId}?api_key=6d4b546936310f017557b2fb498b370b&language={language}";
            var content = await RequestEngine.CallApiAsync(query);
            var movie = RequestEngine.DeserializeJson<MovieDetails>(content);
            return movie;
        }

        public async Task<Images> GetImagesAsync(int movieId, string language = "en")
        {
            string query = "https://api.themoviedb.org/3/movie/" + $"{movieId}?api_key=6d4b546936310f017557b2fb498b370b&language={language}";
            var content = await RequestEngine.CallApiAsync(query);
            var movie = RequestEngine.DeserializeJson<Images>(content);
            return movie;
        }

        public MovieApi() { }
    }
}
