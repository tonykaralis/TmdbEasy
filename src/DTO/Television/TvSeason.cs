using System.Collections.Generic;

namespace TmdbEasy.DTO.TV
{
    public class TvSeason
    {
        public string _id { get; set; }
        public string Air_date { get; set; }
        public List<Episode> Episodes { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public int Id { get; set; }
        public string Poster_path { get; set; }
        public int Season_number { get; set; }
    }
}
