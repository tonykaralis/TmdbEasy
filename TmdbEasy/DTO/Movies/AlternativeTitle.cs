using System.Collections.Generic;

namespace TmdbEasy.DTO.Movies
{
    public class AlternativeTitle
    {
        public int Id { get; set; }
        public List<Titles> Titles { get; set; }
    }
}
