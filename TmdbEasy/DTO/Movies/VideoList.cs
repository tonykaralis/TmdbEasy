using System.Collections.Generic;

namespace TmdbEasy.DTO.Movies
{
    public class VideoList
    {
        public int Id { get; set; }
        public List<Result> Results { get; set; }
    }
}
