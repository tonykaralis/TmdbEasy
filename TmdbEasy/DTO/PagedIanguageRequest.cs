namespace TmdbEasy.DTO
{
    public class PagedIanguageRequest : BaseRequest
    {
        public string Language { get; set; } = "en";
        public int Page { get; set; } = 1;
    }
}
