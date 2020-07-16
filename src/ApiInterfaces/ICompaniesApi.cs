using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.TmdbObjects.Companies;

namespace TMdbEasy.ApiInterfaces
{
    public interface ICompaniesApi : IBase
    {
        /// <summary>
        /// Get a companies details by id.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <returns></returns>
        Task<CompanyDetails> GetDetailsAsync(int id);
        /// <summary>
        /// Get the movies of a company by id.
        /// We highly recommend using Movie Discover instead of this method as it is much more flexible.
        /// </summary>
        /// <param name="id">Typically taken from a previous api call</param>
        /// <param name="language">Pass a ISO 639-1 value to display translated data for the fields that support it. Default is English</param>
        /// <returns></returns>
        Task<MoviesByCompany> GetMoviesAsync(int id, string language = "en");
        /// <summary>
        /// Search for companies.
        /// </summary>
        /// <param name="query">Uri encoded text query</param>
        /// <param name="page">Default is page 1</param>
        /// <returns></returns>
        Task<CompanyList> SearchAsync(string query,int page=1);
    }
}
