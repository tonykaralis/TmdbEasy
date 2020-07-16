using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects.Changes;
using static TMdbEasy.REngine;

namespace TMdbEasy.ApiObjects
{
    internal class ChangesApi : IChangesApi
    {
        public async Task<ChangeList> GetMovieChangeListAsync(string end_date = null, string start_date = null, int page = 1)
        {
            var content = await CallApiAsync(BuildQuery(end_date, start_date, page, "movie")).ConfigureAwait(false);
            return DeserializeJson<ChangeList>(content);
        }

        public async Task<ChangeList> GetPersonChangeListAsync(string end_date = null, string start_date = null, int page = 1)
        {
            var content = await CallApiAsync( BuildQuery(end_date, start_date, page, "person") ).ConfigureAwait(false);
            return DeserializeJson<ChangeList>(content);
        }

        public async Task<ChangeList> GetTVChangeListAsync(string end_date, string start_date, int page  = 1)
        {
            var content = await CallApiAsync( BuildQuery(end_date,start_date,page, "tv") ).ConfigureAwait(false);
            return DeserializeJson<ChangeList>(content);
        }

        /// <summary>
        /// Build the api request query up. Wraps start and end date with %2F.
        /// </summary>
        /// <param name="end_date"></param>
        /// <param name="start_date"></param>
        /// <param name="page"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private string BuildQuery(string end_date, string start_date, int page, string type)
        {
            var query = new StringBuilder();
            query.Append(Url).Append(type).Append("/changes?api_key=").Append(ApiKey);
            if (end_date != null)
            {
                query.Append("&");
                query.Append("end_date=");
                query.Append(end_date.Replace("/", "%2F"));
            }
            if (start_date != null)
            {
                query.Append("&");
                query.Append("start_date=");
                query.Append(start_date.Replace("/", "%2F"));
            }
            query.Append("&");
            query.Append("page=");
            query.Append(page.ToString());
            return query.ToString();
        }
    }
}
