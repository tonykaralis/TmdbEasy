using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.TmdbObjects.Changes;

namespace TMdbEasy.ApiInterfaces
{
    public interface IChangesApi
    {
        /// <summary>
        /// Get a list of all of the movie ids that have been changed in the past 24 hours.
        ///You can query it for up to 14 days worth of changed IDs at a time with the start_date and end_date query parameters.
        ///100 items are returned per page.
        ///Date Format: DD/MM/YYYY
        /// </summary>
        /// <param name="end_date">Filter with an end date</param>
        /// <param name="start_date">Filter with an end date</param>
        /// <param name="page">Page Number</param>
        Task<ChangeList> GetMovieChangeListAsync(string end_date, string start_date, int page);
        /// <summary>
        /// Get a list of all of the movie ids that have been changed in the past 24 hours.
        ///You can query it for up to 14 days worth of changed IDs at a time with the start_date and end_date query parameters.
        ///100 items are returned per page.
        ///Date Format: DD/MM/YYYY
        /// </summary>
        /// <param name="end_date">Filter with an end date</param>
        /// <param name="start_date">Filter with an end date</param>
        /// <param name="page">Page Number</param>
        Task<ChangeList> GetTVChangeListAsync(string end_date, string start_date, int page);
        /// <summary>
        /// Get a list of all of the movie ids that have been changed in the past 24 hours.
        ///You can query it for up to 14 days worth of changed IDs at a time with the start_date and end_date query parameters.
        ///100 items are returned per page.
        ///Date Format: DD/MM/YYYY
        /// </summary>
        /// <param name="end_date">Filter with an end date</param>
        /// <param name="start_date">Filter with an end date</param>
        /// <param name="page">Page Number</param>
        Task<ChangeList> GetPersonChangeListAsync(string end_date, string start_date, int page);
    }
}
