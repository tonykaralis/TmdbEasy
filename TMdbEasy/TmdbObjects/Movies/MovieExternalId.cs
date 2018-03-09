using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Movies
{
    public class MovieExternalId
    {
        public string Imdb_id { get; set; }
        public string Facebook_id { get; set; }
        public string Instagram_id { get; set; }
        public string Twitter_id { get; set; }
        public int Id { get; set; }
    }
}
