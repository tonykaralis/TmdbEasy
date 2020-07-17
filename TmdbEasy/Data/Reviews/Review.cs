namespace TmdbEasy.Data.Reviews
{
    public class Review : ReviewBase
    {
        public string Iso_639_1 { get; set; }
        public int Media_id { get; set; }
        public string Media_title { get; set; }
        public string Media_type { get; set; }
    }
}
