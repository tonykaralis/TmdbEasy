namespace TmdbEasy
{
    public static class QueryExtensions
    {
        public static string AddApiKey(this string query, string key)
        {
            return query.Replace(Constants.ApiKeyPlaceholder, $"{key}");
        }

        public static string AddUrl(this string query, string url)
        {
            return $"{url}{query}";
        }
    }
}
