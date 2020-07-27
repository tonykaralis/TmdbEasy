using System.Collections.Generic;
using System.Threading.Tasks;
using TmdbEasy.DTO.Configuration;

namespace TmdbEasy.Interfaces
{
    public interface IConfigApi : IBaseApi
    {
        /// <summary>
        /// Get the system wide configuration information. Some elements of the API require some knowledge of this configuration data. 
        /// The purpose of this is to try and keep the actual API responses as light as possible. It is recommended you cache this data within your application and 
        /// check for updates every few days.
        /// This method currently holds the data relevant to building image URLs as well as the change key map.
        /// </summary>
        Task<Configuration> GetConfigurationAsync(string userApiKey = null);
        /// <summary>
        /// Get the list of countries (ISO 3166-1 tags) used throughout TMDb.
        /// </summary>
        Task<List<Country>> GetCountriesAsync(string userApiKey = null);
        /// <summary>
        /// Get a list of the jobs and departments we use on TMDb.
        /// </summary>
        Task<List<JobsByDepartment>> GetJobsAsync(string userApiKey = null);
        /// <summary>
        /// Get the list of languages (ISO 639-1 tags) used throughout TMDb.
        /// </summary>
        Task<List<Language>> GetLanguagesAsync(string userApiKey = null);
        /// <summary>
        /// Get the list of timezones used throughout TMDb.
        /// </summary>
        Task<List<TimeZones>> GetTimeZonesAsync(string userApiKey = null);
    }
}
