using System;

namespace TmdbEasy.DTO.Movies
{
    public class ReleaseDate
    {
        public string Certification { get; set; }
        public string Iso_639_1 { get; set; }
        public string Note { get; set; }
        public DateTime Release_date { get; set; }
        public int Type { get; set; }
    }
}
