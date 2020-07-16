using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Images
{
    public class Still
    {
        public double Aspect_ratio { get; set; }
        public string File_path { get; set; }
        public int Height { get; set; }
        public string Iso_639_1 { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
        public int Width { get; set; }
    }
}
