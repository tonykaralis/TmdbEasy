using System.Threading.Tasks;
using TmdbEasy.Data.Changes;
using TmdbEasy.Enums;

namespace TmdbEasy.Interfaces
{
    public interface IChangesApi : IBaseApi
    {
        Task<ChangeList> GetChangeListAsync(string userApiKey = null, string end_date = null, string start_date = null, int page = 1, ChangeType type = ChangeType.Movie);
    }
}
