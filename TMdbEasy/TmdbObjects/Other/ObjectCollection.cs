using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.TmdbObjects.Movies;
using TMdbEasy.TmdbObjects.TV;

namespace TMdbEasy.TmdbObjects.Other
{
    public class ObjectCollection
    {
            public List<Movie> Movie_results { get; set; }
            public List<Person> Person_results { get; set; }
            public List<Tv> Tv_results { get; set; }
            public List<Episode> Tv_episode_results { get; set; }
            public List<TvSeason> Tv_season_results { get; set; }
    }
}
