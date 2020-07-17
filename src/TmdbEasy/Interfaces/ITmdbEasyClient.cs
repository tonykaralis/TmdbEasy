using System.Threading.Tasks;

namespace TmdbEasy.Interfaces
{
    public interface ITmdbEasyClient
    {
        string GetApiKey();

        string GetUrl();

        Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query);
    }
}
