using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMdbEasy
{
    internal static class QueryBuilder
    {
        /// <summary>
        /// Build the api request query by wrapping start and end date with %2F.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="end_date"></param>
        /// <param name="start_date"></param>
        /// <returns></returns>
        public static string BuildDates(this string value, string start_date, string end_date)
        {
            var query = new StringBuilder();
            query.Append(value);
            if (start_date != null)
            {
                query.Append("&");
                query.Append("start_date=");
                query.Append(start_date.Replace("/", "%2F"));
            }
            if (end_date != null)
            {
                query.Append("&");
                query.Append("end_date=");
                query.Append(end_date.Replace("/", "%2F"));
            }
            return query.ToString();
        }
    }
}
