using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Movies
{
    public class ReleaseDate
    {
        public string Certification { get; set; }
        public string Iso_639_1 { get; set; }
        public string Note { get; set; }
        public DateTime Release_date { get; set; }
        public int Type { get; set; }
    }

    public class Result
    {
        public string Iso_3166_1 { get; set; }
        public List<ReleaseDate> Release_dates { get; set; }
    }

    public class MovieReleaseDateList
    {
        public int Id { get; set; }
        public List<Result> Results { get; set; }
    }
}
