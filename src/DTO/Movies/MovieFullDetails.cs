using System.Collections.Generic;
using TmdbEasy.DTO.Language;
using TmdbEasy.DTO.Other;

namespace TmdbEasy.DTO.Movies
{
    public class MovieFullDetails
    {
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public object Belongs_to_collection { get; set; }
        public int Budget { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string Imdb_id { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public object Poster_path { get; set; }
        public List<ProductionCompany> Production_companies { get; set; }
        public List<ProductionCountry> Production_countries { get; set; }
        public string Release_date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public List<SpokenLanguage> Spoken_languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
    }
}
