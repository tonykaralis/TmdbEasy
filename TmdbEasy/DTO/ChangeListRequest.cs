using TmdbEasy.Enums;

namespace TmdbEasy.DTO
{
    public class ChangeListRequest
    {
        public string UserApiKey { get; set; }
        public string End_date { get; set; }
        public string Start_date { get; set; }
        public int Page { get; set; } = 1;
        public ChangeType Type { get; set; } = ChangeType.Movie;
    }
}
