using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Changes
{
    public class Result
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
    }

    public class ChangeList
    {
        public List<Result> Results { get; set; }
        public int Page { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }
}
