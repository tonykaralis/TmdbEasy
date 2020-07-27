using System.Collections.Generic;

namespace TmdbEasy.DTO.Changes
{
    public class ChangeList
    {
        public List<ChangeResult> Results { get; set; }
        public int Page { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }
}
