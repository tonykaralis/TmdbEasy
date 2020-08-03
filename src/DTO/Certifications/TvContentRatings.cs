using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TmdbEasy.Tests.Integration")]
namespace TmdbEasy.DTO.Certifications
{
    public class TvContentRating
    {
        public string Iso_3166_1 { get; set; }
        public string Rating { get; set; }
    }

    internal class TvRatingList
    {
        public List<TvContentRating> Results { get; set; }
    }
}
