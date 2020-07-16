using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Configuration
{
    public class TimeZones
    {
        public string Iso_3166_1 { get; set; }
        public List<string> Zones { get; set; }
    }
}
