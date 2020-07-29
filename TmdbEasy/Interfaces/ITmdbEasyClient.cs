using System.Threading.Tasks;
using TmdbEasy.Configurations;

namespace TmdbEasy.Interfaces
{
    public interface ITmdbEasyClient
    {
        ApiVersion GetVersion();

        Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query);
    }
}
