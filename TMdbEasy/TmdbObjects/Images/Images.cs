using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Images
{
    public class Images
    {
        public int Id { get; set; }
        public List<Backdrop> Backdrops { get; set; }
        public List<Poster> Posters { get; set; }
    }
}
