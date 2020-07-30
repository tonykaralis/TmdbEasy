using System.Threading.Tasks;
using TmdbEasy.DTO.Companies;

namespace TmdbEasy.Interfaces
{
    public interface ICompaniesApi
    {
        /// <summary>
        /// Get a companies details by id.
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        Task<CompanyDetails> GetDetailsAsync(int companyId, string apiKey = null);

        /// <summary>
        /// Get the movies of a company by id.
        /// We highly recommend using Movie Discover instead of this method as it is much more flexible.
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="apiKey"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        Task<MoviesByCompany> GetMoviesAsync(int companyId, string apiKey = null, string language = null);

        /// <summary>
        /// Search for companies with a custom query.
        /// </summary>
        /// <param name="customQuery"></param>
        /// <param name="apiKey"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<CompanyList> SearchAsync(string customQuery, string apiKey = null, int page = 1);
    }
}
