using System.Threading.Tasks;
using TmdbEasy.Constants;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Companies;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class CompaniesApi : BaseApi, ICompaniesApi
    {
        public CompaniesApi(ITmdbEasyClient client) : base(client) { }

        public async Task<CompanyDetails> GetDetailsAsync(IdRequest request)
        {
            string queryString = $"company/{request.Id}?{QueryConstants.ApiKeyVariable}{GetApiKey(request.UserApiKey)}";

            return await _client.GetResponseAsync<CompanyDetails>(queryString).ConfigureAwait(false);
        }

        public async Task<MoviesByCompany> GetMoviesAsync(IdRequest request, string language = "en")
        {
            string queryString = $"company/{request.Id}?{QueryConstants.ApiKeyVariable}{GetApiKey(request.UserApiKey)}";

            return await _client.GetResponseAsync<MoviesByCompany>(queryString).ConfigureAwait(false);
        }

        public async Task<CompanyList> SearchAsync(CustomQueryRequest request, int page = 1)
        {
            string queryString = $"search/company?{QueryConstants.ApiKeyVariable}{GetApiKey(request.UserApiKey)}&query={request.Query}&page={page}";

            return await _client.GetResponseAsync<CompanyList>(queryString).ConfigureAwait(false);
        }
    }
}
