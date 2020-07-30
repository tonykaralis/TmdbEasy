using System.Collections.Generic;

namespace TmdbEasy.DTO.Other
{
    public class Person
    {
        public bool Adult { get; set; }
        public List<object> Also_known_as { get; set; }
        public string Biography { get; set; }
        public string Birthday { get; set; }
        public string Deathday { get; set; }
        public int Gender { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string Imdb_id { get; set; }
        public string Name { get; set; }
        public string Place_of_birth { get; set; }
        public double Popularity { get; set; }
        public string Profile_path { get; set; }
    }
}
