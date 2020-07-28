using System.Threading.Tasks;
using TmdbEasy.DTO.Companies;
using TmdbEasy.Extensions;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class CompaniesApi : ICompaniesApi
    {
        private readonly IRequestHandler _requestHandler;

        public CompaniesApi(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public async Task<CompanyDetails> GetDetailsAsync(int companyId, string apiKey = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"company/{companyId}")
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteRequestAsync<CompanyDetails>(restRequest);
        }

        public async Task<MoviesByCompany> GetMoviesAsync(int companyId, string apiKey = null, string language = null)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"company/{companyId}")
                .AddLanguage(language)
                .AddApiKey(apiKey);

            return await _requestHandler.ExecuteRequestAsync<MoviesByCompany>(restRequest);
        }

        public async Task<CompanyList> SearchAsync(string customQuery, string apiKey = null, int page = 1)
        {
            var restRequest = _requestHandler
                .CreateRequest()
                .AddUrlSegment($"search/company")                
                .AddApiKey(apiKey)
                .AddCustomQuery(customQuery)
                .AddPage(page);

            return await _requestHandler.ExecuteRequestAsync<CompanyList>(restRequest);
        }
    }
}
