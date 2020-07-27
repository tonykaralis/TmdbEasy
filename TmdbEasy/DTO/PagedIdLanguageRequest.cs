namespace TmdbEasy.DTO
{
    public class PagedIdLanguageRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Language { get; set; } = "en";
        public int Page { get; set; } = 1;
    }
}
