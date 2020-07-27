using System.Text;
using System.Threading.Tasks;
using TmdbEasy.DTO.Changes;
using TmdbEasy.DTO;
using TmdbEasy.Extensions;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class ChangesApi : BaseApi, IChangesApi
    {
        public ChangesApi(ITmdbEasyClient client) : base(client) { }

        public async Task<ChangeList> GetChangeListAsync(ChangeListRequest changeListRequest)
        {
            string queryString = new StringBuilder()
            .Append(changeListRequest.Type.ToString().ToLower())
            .Append("/changes?api_key=")
            .Append(GetApiKey(changeListRequest.UserApiKey))
            .AppendEndDate(changeListRequest.End_date)
            .AppendStartDate(changeListRequest.Start_date)
            .Append($"&page={changeListRequest.Page}")
            .ToString();

            return await _client.GetResponseAsync<ChangeList>(queryString).ConfigureAwait(false);
        }       
    }
}
