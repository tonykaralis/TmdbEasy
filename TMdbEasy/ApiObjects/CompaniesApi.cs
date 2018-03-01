using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects.Companies;
using static TMdbEasy.REngine;

namespace TMdbEasy.ApiObjects
{
    internal class CompaniesApi : ICompaniesApi
    {
        public async Task<CompanyDetails> GetDetailsAsync(int id)
        {
            var content = await CallApiAsync($"{Url}company/{id}?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<CompanyDetails>(content);
        }

        public async Task<MoviesByCompany> GetMoviesAsync(int id, string language)
        {
            var content = await CallApiAsync($"{Url}company/{id}/movies?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<MoviesByCompany>(content);
        }
    }
}
