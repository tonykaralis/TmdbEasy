using System.Collections.Generic;

namespace TmdbEasy.DTO.Other
{
    public class MovieCredits
    {
        public int Id { get; set; }
        public List<Cast> Cast { get; set; }
        public List<Crew> Crew { get; set; }
    }
}
