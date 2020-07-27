using System.Collections.Generic;
using System.Threading.Tasks;
using TmdbEasy.Constants;
using TmdbEasy.DTO.Configuration;
using TmdbEasy.Interfaces;

namespace TmdbEasy.Apis
{
    public class ConfigApi : BaseApi, IConfigApi
    {
        public ConfigApi(ITmdbEasyClient client) : base(client) { }

        public async Task<Configuration> GetConfigurationAsync(string userApiKey = null)
        {
            string queryString = $"configuration?{QueryConstants.ApiKeyVariable}{GetApiKey(userApiKey)}";

            return await _client.GetResponseAsync<Configuration>(queryString).ConfigureAwait(false);
        }

        public async Task<List<Country>> GetCountriesAsync(string userApiKey = null)
        {
            string queryString = $"configuration/countries?{QueryConstants.ApiKeyVariable}{GetApiKey(userApiKey)}";

            return await _client.GetResponseAsync<List<Country>>(queryString).ConfigureAwait(false);
        }

        public async Task<List<JobsByDepartment>> GetJobsAsync(string userApiKey = null)
        {
            string queryString = $"configuration/jobs?{QueryConstants.ApiKeyVariable}{GetApiKey(userApiKey)}";

            return await _client.GetResponseAsync<List<JobsByDepartment>>(queryString).ConfigureAwait(false);
        }

        public async Task<List<Language>> GetLanguagesAsync(string userApiKey = null)
        {
            string queryString = $"configuration/languages?{QueryConstants.ApiKeyVariable}{GetApiKey(userApiKey)}";

            return await _client.GetResponseAsync<List<Language>>(queryString).ConfigureAwait(false);
        }

        public async Task<List<TimeZones>> GetTimeZonesAsync(string userApiKey = null)
        {
            string queryString = $"configuration/timezones?{QueryConstants.ApiKeyVariable}{GetApiKey(userApiKey)}";

            return await _client.GetResponseAsync<List<TimeZones>>(queryString).ConfigureAwait(false);
        }
    }
}
