namespace TmdbEasy.DTO
{
    public class IdLanguageRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Language { get; set; } = "en";
    }
}
