using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects
{
    public class Part
    {
        public bool Adult { get; set; }
        public object Backdrop_path { get; set; }
        public List<int> Genre_ids { get; set; }
        public int Id { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public string Release_date { get; set; }
        public string Poster_path { get; set; }
        public double Popularity { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
    }

    public class Collections
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public object Poster_path { get; set; }
        public string Backdrop_path { get; set; }
        public List<Part> Parts { get; set; }
    }
}
