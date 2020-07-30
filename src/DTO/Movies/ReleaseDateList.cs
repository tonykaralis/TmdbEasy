using System;
using System.Collections.Generic;

namespace TmdbEasy.DTO.Movies
{
    public class ReleaseDateList
    {
        public string Iso_3166_1 { get; set; }
        public List<ReleaseDate> Release_dates { get; set; }
    }
}
