using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.TV
{
    public class TvCrew
    {
        public int Id { get; set; }
        public string Credit_id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public string Profile_path { get; set; }
    }

    public class GuestStar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Credit_id { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
        public string Profile_path { get; set; }
    }

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
