using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Changes
{
    public class TVChangeList
    {
        public class Item
        {
            public string Id { get; set; }
            public string Action { get; set; }
            public string Time { get; set; }
            public string Iso_639_1 { get; set; }
            public string Value { get; set; }
        }

        public class Change
        {
            public string Key { get; set; }
            public List<Item> Items { get; set; }
        }

        public class MovieChangeList
        {
            public List<Change> Changes { get; set; }
        }
    }
}
