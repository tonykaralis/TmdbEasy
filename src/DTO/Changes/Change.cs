using System.Collections.Generic;

namespace TmdbEasy.DTO.Changes
{
    public class Change
    {
        public string Key { get; set; }
        public List<Item> Items { get; set; }
    }
}
