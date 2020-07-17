using System.Threading.Tasks;

namespace TmdbEasy.Interfaces
{
    public interface ITmdbEasyClient
    {
        Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query);
    }
}
