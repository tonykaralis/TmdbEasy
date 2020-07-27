namespace TmdbEasy.DTO
{
    public class IdCountryRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Country { get; set; } = "BR";
    }
}
