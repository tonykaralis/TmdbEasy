using System.Threading.Tasks;

namespace TmdbEasy.Interfaces
{
    public interface IRequestHandler
    {
        Request CreateRequest();

        Task<TmdbEasyModel> ExecuteAsync<TmdbEasyModel>(Request request);
    }
}
