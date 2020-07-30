using System.Collections.Generic;

namespace TmdbEasy.DTO.Movies
{
    public class DatedMovieList
    {
        public int Page { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
        public List<Movie> Results { get; set; }
        public Dates Dates { get; set; }
    }
}
