using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Movies
{
    public class Titles
    {
        public string Iso_3166_1 { get; set; }
        public string Title { get; set; }
    }

    public class AlternativeTitle
    {
        public int Id { get; set; }
        public List<Titles> Titles { get; set; }
    }
}
