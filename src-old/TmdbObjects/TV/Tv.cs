using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.TmdbObjects.Other;
using TMdbEasy.TmdbObjects.Production;

namespace TMdbEasy.TmdbObjects.TV
{
    public class CreatedBy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Profile_path { get; set; }
    }

    public class SeasonBase
    {
        public string Air_date { get; set; }
        public int Episode_count { get; set; }
        public int Id { get; set; }
        public string Poster_path { get; set; }
        public int Season_number { get; set; }
    }

    public class Tv
    {
        public string Backdrop_path { get; set; }
        public List<CreatedBy> Created_by { get; set; }
        public List<int> Episode_run_time { get; set; }
        public string First_air_date { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public bool In_production { get; set; }
        public List<string> Languages { get; set; }
        public string Last_air_date { get; set; }
        public string Name { get; set; }
        public List<Network> Networks { get; set; }
        public int Number_of_episodes { get; set; }
        public int Number_of_seasons { get; set; }
        public List<string> Origin_country { get; set; }
        public string Original_language { get; set; }
        public string Original_name { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public List<ProductionCompany> Production_companies { get; set; }
        public List<SeasonBase> Seasons { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public double Vote_average { get; set; } // from int to double
        public int Vote_count { get; set; }
    }

    public class TVShowList
    {
        public int Page { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
        public List<Tv> Results { get; set; }
    }
}
