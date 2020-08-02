using System.Threading.Tasks;
using TmdbEasy.DTO.Changes;
using TmdbEasy.DTO.Images;
using TmdbEasy.DTO.Language;
using TmdbEasy.DTO.Movies;
using TmdbEasy.DTO.Other;
using TmdbEasy.DTO.Reviews;
using TmdbEasy.Extensions;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class MovieApi : IMovieApi
    {
        private readonly IRequestHandler _requestHandler;
        private readonly ITmdbEasyClient _client;

        public MovieApi(ITmdbEasyClient client)
        {
            _client = client;
            _requestHandler = new RequestHandler(_client);
        }

        public async Task<MovieFullDetails> GetDetailsAsync(int movieId, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment("movie")
                .AddUrlSegment($"{movieId}")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieFullDetails>(restRequest);
        }

        public async Task<Images> GetImagesAsync(int movieId, string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment("movie")
                .AddUrlSegment($"{movieId}")
                .AddUrlSegment("images")
                .AddApiKey(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<Images>(restRequest);
        }

        public async Task<AlternativeTitle> GetAlternativeTitlesAsync(int movieId, string country = null, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddUrlSegment("alternative_titles")
               .AddCountry(country)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<AlternativeTitle>(restRequest);
        }
        
        public async Task<MovieChangeList> GetChangesAsync(int movieId, string end_date = null, string start_date = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddStartDate(start_date)
               .AddEndDate(end_date)
               .AddPage(1)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieChangeList>(restRequest);
        }
        
        public async Task<MovieCredits> GetCreditsAsync(int movieId, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddUrlSegment("credits")
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieCredits>(restRequest);
        }
       
        public async Task<MovieExternalId> GetExternalIdsAsync(int movieId, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddUrlSegment("external_ids")
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieExternalId>(restRequest);
        }

        public async Task<MovieReleaseDateList> GetReleaseDatesAsync(int movieId, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddUrlSegment("release_dates")
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieReleaseDateList>(restRequest);
        }

        public async Task<VideoList> GetVideosAsync(int movieId, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddUrlSegment("videos")
   
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<VideoList>(restRequest);
        }

        public async Task<TranslationList> GetTranslationsAsync(int movieId, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddUrlSegment("translations")
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<TranslationList>(restRequest);
        }
       
        public async Task<MovieList> GetRecommendationsAsync(int movieId, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddUrlSegment("recommendations")
               .AddLanguage(language)
               .AddPage(page)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieList>(restRequest);
        }
        
        public async Task<MovieList> GetSimilarMoviesAsync(int movieId, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddUrlSegment("similar")
               .AddLanguage(language)
               .AddPage(page)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieList>(restRequest);
        }
       
        public async Task<UserReview> GetUserReviewsAsync(int movieId, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment($"{movieId}")
               .AddUrlSegment("reviews")
               .AddLanguage(language)
               .AddPage(page)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<UserReview>(restRequest);
        }
        
        public async Task<MovieFullDetails> GetLatestAsync(string language = null, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment("latest")
               .AddLanguage(language)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieFullDetails>(restRequest);
        }
       
        public async Task<DatedMovieList> GetNowPlayingAsync(string region = null, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment("now_playing")
               .AddLanguage(language)
               .AddPage(page)
               .AddRegion(region)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<DatedMovieList>(restRequest);
        }
     
        public async Task<MovieList> GetPopularAsync(string region = null, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment("popular")
               .AddLanguage(language)
               .AddPage(page)
               .AddRegion(region)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieList>(restRequest);
        }
        
        public async Task<MovieList> GetTopRatedAsync(string region = null, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment("top_rated")
               .AddLanguage(language)
               .AddPage(page)
               .AddRegion(region)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieList>(restRequest);
        }
       
        public async Task<DatedMovieList> GetUpcomingAsync(string region = null, string language = null, int page = 1, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("movie")
               .AddUrlSegment("upcoming")
               .AddLanguage(language)
               .AddPage(page)
               .AddRegion(region)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<DatedMovieList>(restRequest);
        }

        public async Task<MovieList> SearchMoviesAsync(string query, string language = null, int page = 1, bool include_adult = false, string region = null,
            int year = default, int primary_release_year = default, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("search")
               .AddUrlSegment("movie")
               .AddCustomQuery(query)
               .AddLanguage()
               .AddPage(page)
               .AddRegion(region)
               .AddLanguage(language)
               .AddYear(year)
               .AddPrimaryReleaseYear(primary_release_year)
               .AddApiKey(apiKey);

            return await _requestHandler.ExecuteAsync<MovieList>(restRequest);
        }

        public async Task<MovieList> SearchByActorAsync(string query, string language = null, int page = 1, bool include_adult = false, string region = null, string apiKey = null)
        {
            var restRequest = _requestHandler
               .CreateRequest()
               .AddUrlSegment("search")
               .AddUrlSegment("person")
               .AddApiKey(apiKey)
               .AddLanguage(language)
               .AddPage(page)
               .AddCustomQuery(query)
               .AddRegion(region)
               .AddIncludeAdult();

            return await _requestHandler.ExecuteAsync<MovieList>(restRequest);
        }
    }
}
