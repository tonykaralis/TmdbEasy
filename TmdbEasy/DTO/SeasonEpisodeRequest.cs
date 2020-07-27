namespace TmdbEasy.DTO
{
    public class SeasonEpisodeRequest : BaseRequest
    {
        public int Id { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
    }
}
