using System.Collections.Generic;

namespace TmdbEasy.DTO.Lists
{
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
}
