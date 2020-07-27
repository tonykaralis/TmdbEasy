namespace TmdbEasy.DTO
{
    public class CustomQueryRequest : BaseRequest
    {
        public string Query { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
    }
}
