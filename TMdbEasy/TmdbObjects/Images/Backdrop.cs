using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Images
{
    public class Backdrop
    {
        public double Aspect_ratio { get; set; }
        public string File_path { get; set; }
        public int Height { get; set; }
        public object Iso_639_1 { get; set; }
        public int Vote_average { get; set; }
        public int Vote_count { get; set; }
        public int Width { get; set; }
    }
}
