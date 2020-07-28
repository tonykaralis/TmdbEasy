//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TMdbEasy.ApiInterfaces;
//using TMdbEasy.TmdbObjects.Changes;
//using TMdbEasy.TmdbObjects.Images;
//using TMdbEasy.TmdbObjects.Language;
//using TMdbEasy.TmdbObjects.Movies;
//using TMdbEasy.TmdbObjects.Other;
//using static TMdbEasy.REngine;

//namespace TMdbEasy.ApiObjects
//{
//    sealed class MovieApi : IMovieApi
//    {
//        public async Task<MovieFullDetails> GetDetailsAsync(int id, string language = "en")
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}?api_key={ApiKey}&language={language}").ConfigureAwait(false);
//            return DeserializeJson<MovieFullDetails>(content);
//        }

//        public async Task<Images> GetImagesAsync(int id, string language = "en")
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}/images?api_key={ApiKey}&language={language}").ConfigureAwait(false);
//            return DeserializeJson<Images>(content);
//        }

//        public async Task<AlternativeTitle> GetAlternativeTitlesAsync(int id, string country = "en")
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}/alternative_titles?api_key={ApiKey}&language={country}").ConfigureAwait(false);
//            return DeserializeJson<AlternativeTitle>(content);
//        }
//        //not tested
//        public async Task<MovieChangeList> GetChangesAsync(int id, string start_date, string end_date, int page = 1)
//        {
//            string query = $"{Url}movie/{id}/changes?api_key={ApiKey}";
//            query.BuildDates(start_date, end_date);
//            query += $"&page={page}";
//            var content = await CallApiAsync(query).ConfigureAwait(false);
//            return DeserializeJson<MovieChangeList>(content);
//        }
//        //not tested
//        public async Task<MovieCredits> GetCreditsAsync(int id)
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}/credits?api_key={ApiKey}").ConfigureAwait(false);
//            return DeserializeJson<MovieCredits>(content);
//        }
//        //not tested
//        public async Task<MovieExternalId> GetExternalIdsAsync(int id)
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}/external_ids?api_key={ApiKey}").ConfigureAwait(false);
//            return DeserializeJson<MovieExternalId>(content);
//        }
//        //not tested
//        public async Task<MovieReleaseDateList> GetReleaseDatesAsync(int id)
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}/release_dates?api_key={ApiKey}").ConfigureAwait(false);
//            return DeserializeJson<MovieReleaseDateList>(content);
//        }
//        //not tested
//        public async Task<VideoList> GetVideosAsync(int id)
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}/videos?api_key={ApiKey}").ConfigureAwait(false);
//            return DeserializeJson<VideoList>(content);
//        }
//        //not tested
//        public async Task<TranslationsList> GetTranslationsAsync(int id)
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}/translations?api_key={ApiKey}").ConfigureAwait(false);
//            return DeserializeJson<TranslationsList>(content);
//        }
//        //not tested
//        public async Task<MovieList> GetRecommendationsAsync(int id, string language="en", int page=1)
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}/recommendations?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
//            return DeserializeJson<MovieList>(content);
//        }
//        //not tested
//        public async Task<MovieList> GetSimilarMoviesAsync(int id, string language = "en", int page = 1)
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}/similar?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
//            return DeserializeJson<MovieList>(content);
//        }
//        //not tested
//        public async Task<UserReviews> GetUserReviewsAsync(int id, string language = "en", int page = 1)
//        {
//            var content = await CallApiAsync($"{Url}movie/{id}reviews?api_key={ApiKey}&language={language}&page={page}").ConfigureAwait(false);
//            return DeserializeJson<UserReviews>(content);
//        }
//        //not tested
//        public async Task<MovieFullDetails> GetLatestAsync(string language = "en")
//        {
//            var content = await CallApiAsync($"{Url}movie/latest?api_key={ApiKey}&language={language}").ConfigureAwait(false);
//            return DeserializeJson<MovieFullDetails>(content);
//        }
//        //not tested
//        public async Task<DatedMovieList> GetNowPlayingAsync(string language = "en", int page=1, string region="US")
//        {
//            var content = await CallApiAsync($"{Url}movie/now_playing?api_key={ApiKey}&language={language}&page={page}&region={region}").ConfigureAwait(false);
//            return DeserializeJson<DatedMovieList>(content);
//        }
//        //not tested
//        public async Task<MovieList> GetPopularAsync(string language = "en", int page=1, string region = "US")
//        {
//            var content = await CallApiAsync($"{Url}movie/popular?api_key={ApiKey}&language={language}&page={page}&region={region}").ConfigureAwait(false);
//            return DeserializeJson<MovieList>(content);
//        }
//        //not tested
//        public async Task<MovieList> GetTopRatedAsync(string language = "en", int page=1, string region = "US")
//        {
//            var content = await CallApiAsync($"{Url}movie/top_rated?api_key={ApiKey}&language={language}&page={page}&region={region}").ConfigureAwait(false);
//            return DeserializeJson<MovieList>(content);
//        }
//        //not tested
//        public async Task<DatedMovieList> GetUpcomingAsync(string language = "en", int page=1, string region = "US")
//        {
//            var content = await CallApiAsync($"{Url}movie/upcoming?api_key={ApiKey}&language={language}&page={page}&region={region}").ConfigureAwait(false);
//            return DeserializeJson<DatedMovieList>(content);
//        }
//        //not tested
//        public async Task<MovieList> SearchMoviesAsync(string query, string language = "en", int page = 1, bool include_adult = false, string region = "US", int year = 0, int primary_release_year = 0)
//        {
//            var content = await CallApiAsync($"{Url}search/movie?api_key={ApiKey}&language={language}&query={query}" +
//                $"&page={page}&include_adult={include_adult}&region={region}").ConfigureAwait(false);
//            if (year > 0 && primary_release_year > 0)
//            {
//                content += $"&year={year}&primary_release_year={primary_release_year}";
//            }

//            return DeserializeJson<MovieList>(content);
//        }
//        /// <summary>
//        /// Search by actor
//        /// </summary>
//        /// <param name="query"></param>
//        /// <param name="language"></param>
//        /// <param name="page"></param>
//        /// <param name="include_adult"></param>
//        /// <param name="region"></param>
//        /// <returns></returns>
//        public async Task<MovieList> SearchByActorAsync(string query, string language = "en", int page = 1, bool include_adult = false, string region = "US")
//        {
//            var content = await CallApiAsync($"{Url}search/person?api_key={ApiKey}&language={language}&query={query}" +
//                $"&page={page}&include_adult={include_adult}&region={region}").ConfigureAwait(false);

//            return DeserializeJson<MovieList>(content);
//        }
//    }
//}
