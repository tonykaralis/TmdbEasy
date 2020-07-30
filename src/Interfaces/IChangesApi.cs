using System.Threading.Tasks;
using TmdbEasy.DTO.Changes;
using TmdbEasy.Enums;

namespace TmdbEasy.Interfaces
{
    public interface IChangesApi
    {
        /// <summary>
        /// Get a list of all of the movie/person/tv ids that have been changed in the past 24 hours.
        /// You can query it for up to 14 days worth of changed IDs at a time with the start_date and end_date query parameters.
        /// 100 items are returned per page.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="end_date"></param>
        /// <param name="start_date"></param>
        /// <param name="page"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<ChangeList> GetChangeListAsync(ChangeType type, string end_date = null, string start_date = null, int page = 1, string apiKey = null);
    }
}
