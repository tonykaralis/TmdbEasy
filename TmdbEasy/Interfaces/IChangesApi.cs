using System.Threading.Tasks;
using TmdbEasy.DTO.Changes;
using TmdbEasy.DTO;

namespace TmdbEasy.Interfaces
{
    public interface IChangesApi : IBaseApi
    {
        Task<ChangeList> GetChangeListAsync(ChangeListRequest changeListRequest);
    }
}
