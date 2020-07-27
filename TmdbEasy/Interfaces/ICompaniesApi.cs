using System.Threading.Tasks;
using TmdbEasy.DTO;
using TmdbEasy.DTO.Companies;

namespace TmdbEasy.Interfaces
{
    public interface ICompaniesApi : IBaseApi
    {
        /// <summary>
        /// Get a companies details by id.
        /// </summary>
        Task<CompanyDetails> GetDetailsAsync(IdRequest request);
        /// <summary>
        /// Get the movies of a company by id.
        /// We highly recommend using Movie Discover instead of this method as it is much more flexible.
        /// </summary>
        Task<MoviesByCompany> GetMoviesAsync(IdRequest request, string language = "en");
        /// <summary>
        /// Search for companies.
        /// </summary>
        /// <param name="query">Uri encoded text query</param>
        /// <param name="page">Default is page 1</param>
        Task<CompanyList> SearchAsync(string query, int page = 1);
    }
}
