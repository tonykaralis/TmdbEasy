using System.Collections.Generic;
using TmdbEasy.DTO.Movies;

namespace TmdbEasy.DTO.Companies
{
    public class MoviesByCompany
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }
}
