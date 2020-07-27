namespace TmdbEasy.DTO
{
    public class PagedIdRequest : BaseRequest
    {
        public int Id { get; set; }
        public int Page { get; set; } = 1;
    }
}
