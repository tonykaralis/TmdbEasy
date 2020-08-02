using System.Threading.Tasks;

namespace TmdbEasy.Interfaces
{
    internal interface IRequestHandler
    {
        Request CreateRequest();

        Task<TmdbEasyModel> ExecuteAsync<TmdbEasyModel>(Request request);
    }
}
