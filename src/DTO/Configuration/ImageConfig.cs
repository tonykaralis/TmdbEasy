using System.Collections.Generic;

namespace TmdbEasy.DTO.Configuration
{
    public class ImageConfig
    {
        public string Base_url { get; set; }
        public string Secure_base_url { get; set; }
        public List<string> Backdrop_sizes { get; set; }
        public List<string> Logo_sizes { get; set; }
        public List<string> Poster_sizes { get; set; }
        public List<string> Profile_sizes { get; set; }
        public List<string> Still_sizes { get; set; }
    }
}
