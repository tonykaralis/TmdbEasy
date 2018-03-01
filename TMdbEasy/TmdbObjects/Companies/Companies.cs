using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.TmdbObjects.Movies;

namespace TMdbEasy.TmdbObjects.Companies
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
