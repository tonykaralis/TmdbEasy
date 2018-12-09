using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TMdbEasy.Parsers;
using TMdbEasy.TmdbObjects.Images;
using TMdbEasy.TmdbObjects.Movies;
using TMdbEasy.TmdbObjects.TV;

namespace TMdbEasy.TmdbObjects.Other
{
    public class PersonBase
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class PersonFromSearch
    {
        /// <summary>
        /// Popularity of the person calculated from the
        /// number of views for the day and the previous days score.
        /// </summary>
        public double Popularity { get; }

        /// <summary>
        /// ID of the person.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Pictures of the person.
        /// </summary>
        public ImageContainer Poster { get; }

        /// <summary>
        /// Name of the person.
        /// </summary>
        public string Name { get; }

        public KnownForContainer KnownFor { get; }

        /// <summary>
        /// True if this person is an adult actor.
        /// </summary>
        public bool IsAdult { get; }



        public PersonFromSearch(
            [JsonProperty("popularity")] double popularity,
            [JsonProperty("id")] int id,
            [JsonProperty("profile_path")] string posterPath,
            [JsonProperty("name")] string name,
            [JsonProperty("known_for")][JsonConverter(typeof(SearchPersonParser))] KnownForContainer knownFor,
            [JsonProperty("adult")] bool isAdult)
        {
            Popularity = popularity;
            ID = id;
            Poster = new ImageContainer(posterPath);
            Name = name;
            KnownFor = knownFor;
            IsAdult = isAdult;
        }
    }

    public class KnownForContainer
    {
        public List<BasicTvDetails> Television { get; }
        public List<Movie> Movies { get; }



        public KnownForContainer(List<BasicTvDetails> television, List<Movie> movies)
        {
            Television = television;
            Movies = movies;
        }
    }

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
