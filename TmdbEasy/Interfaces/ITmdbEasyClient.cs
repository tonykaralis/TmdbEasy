using System.Threading.Tasks;
using TmdbEasy.Configurations;

namespace TmdbEasy.Interfaces
{
    public interface ITmdbEasyClient
    {
        string GetBaseUrl();

        ApiVersion GetVersion();

        Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query, string userAuthToken);
    }
}
