using System;
using System.Collections.Generic;

namespace TmdbEasy.DTO.Movies
{
    public class MovieReleaseDateList
    {
        public int Id { get; set; }
        public List<ReleaseDateList> Results { get; set; }
    }
}
