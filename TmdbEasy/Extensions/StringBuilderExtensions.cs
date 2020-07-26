using System.Text;

namespace TmdbEasy.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendStartDate(this StringBuilder builder, string start_date)
        {
            if (string.IsNullOrEmpty(start_date))
            {
                builder.Append("&");
                builder.Append("start_date=");
                builder.Append(start_date.Replace("/", "%2F"));
            }

            return builder;
        }

        public static StringBuilder AppendEndDate(this StringBuilder builder, string end_date)
        {
            if (string.IsNullOrEmpty(end_date))
            {
                builder.Append("&");
                builder.Append("end_date=");
                builder.Append(end_date.Replace("/", "%2F"));
            }

            return builder;
        }
    }
}
