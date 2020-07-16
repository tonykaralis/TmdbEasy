using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Certifications
{
    public class TvContentRating
    {
        public string Iso_3166_1 { get; set; }
        public string Rating { get; set; }
    }

    public class TvRatingList
    {
        public List<TvContentRating> Results { get; set; }
    }
}
