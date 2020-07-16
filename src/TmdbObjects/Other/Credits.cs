using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy.TmdbObjects.Other
{
    public class Season
    {
        public string Air_date { get; set; }
        public string Poster_path { get; set; }
        public int Season_number { get; set; }
    }

    public class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Original_name { get; set; }
        public string Character { get; set; }
        public List<object> Episodes { get; set; }
        public List<Season> Seasons { get; set; }
    }

    public class Credits
    {
        public string Credit_type { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public Media Media { get; set; }
        public string Media_type { get; set; }
        public string Id { get; set; }
        public PersonBase Person { get; set; }
    }

    public class Cast
    {
        public int Cast_id { get; set; }
        public string Character { get; set; }
        public string Credit_id { get; set; }
        public int Gender { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Profile_path { get; set; }
    }

    public class Crew
    {
        public string Credit_id { get; set; }
        public string Department { get; set; }
        public int Gender { get; set; }
        public int Id { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
        public string Profile_path { get; set; }
    }

    public class MovieCredits
    {
        public int Id { get; set; }
        public List<Cast> Cast { get; set; }
        public List<Crew> Crew { get; set; }
    }
}
