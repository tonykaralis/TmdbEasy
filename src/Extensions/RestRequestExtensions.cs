namespace TmdbEasy.Extensions
{
    internal static class RestRequestExtensions
    {
        public static Request AddRegion(this Request request, string region)
        {
            return request.AddParameter("region", region);
        }

        public static Request AddCountry(this Request request, string country)
        {
            return request.AddParameter("country", country);
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

        public static Request AddIncludeAdult(this Request request)
        {
            return request.AddParameter("include_adult", "true");
        }

        public static Request AddYear(this Request request, int year)
        {
            if (year > 0)
            {
                return request.AddParameter("year", $"{year}");
            }

            return request;
        }

        public static Request AddPrimaryReleaseYear(this Request request, int primaryReleaseYear)
        {
            if (primaryReleaseYear > 0)
            {
                return request.AddParameter("primary_release_year", $"{primaryReleaseYear}");
            }

            return request;
        }

        public static Request AddFirstAirDateYear(this Request request, int firstAirDateYear)
        {
            if (firstAirDateYear > 0)
            {
                return request.AddParameter("first_air_date_year", $"{firstAirDateYear}");
            }

            return request;
        }
    }
}
