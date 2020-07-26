using System.Text;
using System.Threading.Tasks;
using TmdbEasy.Data.Changes;
using TmdbEasy.Enums;
using TmdbEasy.Interfaces;
using TmdbEasy.Extensions;

namespace TmdbEasy.Apis
{
    public class ChangesApi : BaseApi, IChangesApi
    {
        public ChangesApi(ITmdbEasyClient client) : base(client) { }

        public async Task<ChangeList> GetChangeListAsync(string userApiKey = null, string end_date = null, string start_date = null, int page = 1, ChangeType type = ChangeType.Movie)
        {
            string queryString = new StringBuilder()
            .Append(type.ToString().ToLower())
            .Append("/changes?api_key=")
            .Append(GetApiKey(userApiKey))
            .AppendEndDate(end_date)
            .AppendStartDate(start_date)
            .Append($"&page={page}")
            .ToString();

            return await _client.GetResponseAsync<ChangeList>(queryString).ConfigureAwait(false);
        }       
    }
}
