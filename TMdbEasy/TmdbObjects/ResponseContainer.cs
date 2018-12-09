using Newtonsoft.Json;
using System.Collections.Generic;

namespace TMdbEasy.TmdbObjects
{
    public class ResponseContainer<T>
    {
        /// <summary>
        /// Index of the current page where the results from.
        /// </summary>
        public int CurrentPage { get; }
        
        /// <summary>
        /// Defines what is the biggest page index.
        /// </summary>
        public int TotalPages { get; }


        /// <summary>
        /// Represents how many results can You get if
        /// You call every page index after each other.
        /// </summary>
        public int TotalResults { get; }

        /// <summary>
        /// Actual results from the API.
        /// </summary>
        public List<T> Results { get; }



        public ResponseContainer(
            [JsonProperty("page")] int currentPage,
            [JsonProperty("total_results")] int totalResults,
            [JsonProperty("total_pages")] int totalPages,
            [JsonProperty("results")] List<T> results)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;

            TotalResults = totalResults;
            Results = results;
        }
    }
}
