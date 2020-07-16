using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Configuration
{
    public class Images
    {
        public string Base_url { get; set; }
        public string Secure_base_url { get; set; }
        public List<string> Backdrop_sizes { get; set; }
        public List<string> Logo_sizes { get; set; }
        public List<string> Poster_sizes { get; set; }
        public List<string> Profile_sizes { get; set; }
        public List<string> Still_sizes { get; set; }
    }

    public class Configurations
    {
        public Images Images { get; set; }
        public List<string> Change_keys { get; set; }
    }
}
