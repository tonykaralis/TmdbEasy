using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Lists
{
    public class Item
    {
        public string Poster_path { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string Release_date { get; set; }
        public string Original_title { get; set; }
        public List<int> Genre_ids { get; set; }
        public int Id { get; set; }
        public string Media_type { get; set; }
        public string Original_language { get; set; }
        public string Title { get; set; }
        public object Backdrop_path { get; set; }
        public double Popularity { get; set; }
        public int Vote_count { get; set; }
        public bool Video { get; set; }
        public double Vote_average { get; set; }
    }

    public class ListDetails
    {
        public string Created_by { get; set; }
        public string Description { get; set; }
        public int Favorite_count { get; set; }
        public string Id { get; set; }
        public List<Item> Items { get; set; }
        public int Item_count { get; set; }
        public string Iso_639_1 { get; set; }
        public string Name { get; set; }
        public string Poster_path { get; set; }
    }

    public class ItemStatus
    {
        public string Id { get; set; }
        public bool Item_present { get; set; }
    }
}
