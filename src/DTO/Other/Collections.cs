using System.Collections.Generic;

namespace TmdbEasy.DTO.Other
{
    public class Collections
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public object Poster_path { get; set; }
        public string Backdrop_path { get; set; }
        public List<CollectionPart> Parts { get; set; }
    }
}
