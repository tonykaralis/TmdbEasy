using System.Threading.Tasks;
using TmdbEasy.Configurations;

namespace TmdbEasy.Interfaces
{
    public interface ITmdbEasyClient
    {
        TmdbEasyOptions Options { get; }

        Task<TmdbEasyModel> GetResponseAsync<TmdbEasyModel>(string query);
    }
}
