using System.Threading.Tasks;
using TmdbEasy.Configurations;

namespace TmdbEasy.Interfaces
{
    public interface ITmdbEasyClient
    {
        string GetBaseUrl();

        string GetApiKey();

        ApiVersion GetVersion();

        string GetDefaultLanguage();

        Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query);
    }
}
