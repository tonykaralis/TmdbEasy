using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TmdbEasy.Interfaces;

[assembly: InternalsVisibleTo("TmdbEasy.Tests.Unit")]
namespace TmdbEasy
{
    internal class RequestHandler : IRequestHandler
    {
        private readonly ITmdbEasyClient _client;

        public RequestHandler(ITmdbEasyClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Request CreateRequest()
        {
            return new Request(_client.Options);
        }

        public async Task<TmdbEasyModel> ExecuteAsync<TmdbEasyModel>(Request request)
        {
            return await _client.GetResponseAsync<TmdbEasyModel>(request.GetUri()).ConfigureAwait(false);
        }
    }
}
