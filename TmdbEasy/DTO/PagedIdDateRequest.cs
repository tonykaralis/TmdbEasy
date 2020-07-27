namespace TmdbEasy.DTO
{
    public class PagedIdDateRequest : BaseRequest
    {
        public int Id { get; set; }
        public string End_date { get; set; }
        public string Start_date { get; set; }
        public int Page { get; set; } = 1;
    }
}
