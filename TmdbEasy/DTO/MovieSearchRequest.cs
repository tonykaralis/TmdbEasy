namespace TmdbEasy.DTO
{
    public class MovieSearchRequest : BaseRequest
    {
        public string Language { get; set; } = "en";
        public int Page { get; set; } = 1;
        public string Query { get; set; }
        public bool Include_adult { get; set; }
        public string Region { get; set; } = "US";
        public int Year { get; set; }
        public int Primary_release_year { get; set; }
    }
}
