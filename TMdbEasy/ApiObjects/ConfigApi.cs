using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects.Configuration;
using static TMdbEasy.REngine;

namespace TMdbEasy.ApiObjects
{
    internal class ConfigApi : IConfigApi
    {
        public async Task<Configurations> GetConfigurationAsync()
        {
            var content = await CallApiAsync($"{Url}configuration/?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<Configurations>(content);
        }

        public async Task<Countries> GetCountriesAsync()
        {
            var content = await CallApiAsync($"{Url}configuration/countries?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<Countries>(content);
        }

        public async Task<Jobs> GetJobsAsync()
        {
            var content = await CallApiAsync($"{Url}configuration/jobs?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<Jobs>(content);
        }

        public async Task<Languages> GetLanguagesAsync()
        {
            var content = await CallApiAsync($"{Url}configuration/languages?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<Languages>(content);
        }

        public async Task<TimeZones> GetTimeZonesAsync()
        {
            var content = await CallApiAsync($"{Url}configuration/timezones?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<TimeZones>(content);
        }
    }
}
