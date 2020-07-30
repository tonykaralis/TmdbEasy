using System.Collections.Generic;

namespace TmdbEasy.DTO.TV
{
    public class Episode
    {
        public string Air_date { get; set; }
        public List<TvCrew> Crew { get; set; }
        public int Episode_number { get; set; }
        public List<GuestStar> Guest_stars { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public int Id { get; set; }
        public string Production_code { get; set; }
        public int Season_number { get; set; }
        public string Still_path { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
    }
}
