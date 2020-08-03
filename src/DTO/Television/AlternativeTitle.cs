using System.Collections.Generic;
using TmdbEasy.DTO.Movies;

namespace TmdbEasy.DTO.Television
{
    public class AlternativeTitle
    {
        public int Id { get; set; }
        public List<Titles> Results { get; set; }
    }
}
