namespace TmdbEasy.Extensions
{
    public static class RestRequestExtensions
    {
        public static Request AddRegion(this Request request, string region)
        {
            return request.AddParameter("region", region);
        }

        public static Request AddPage(this Request request, int page)
        {
            return request.AddParameter("page", page.ToString());
        }

        public static Request AddCustomQuery(this Request request, string query)
        {
            return request.AddParameter("query", query);
        }

        public static Request AddStartDate(this Request request, string startDate)
        {
            return request.AddParameter("start_date", startDate?.Replace("/", "%2F"));
        }

        public static Request AddEndDate(this Request request, string endDate)
        {
            return request.AddParameter("end_date", endDate?.Replace("/", "%2F"));
        }
    }
}
