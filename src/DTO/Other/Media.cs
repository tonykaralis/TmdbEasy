using System.Collections.Generic;

namespace TmdbEasy.DTO.Other
{
    public class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Original_name { get; set; }
        public string Character { get; set; }
        public List<object> Episodes { get; set; }
        public List<Season> Seasons { get; set; }
    }
}
