using System.Collections.Generic;

namespace TmdbEasy.DTO.Movies
{
    public class VideoList
    {
        public int Id { get; set; }
        public List<Video> Results { get; set; }
    }
}
