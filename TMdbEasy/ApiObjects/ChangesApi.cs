using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects.Changes;

namespace TMdbEasy.ApiObjects
{
    internal class ChangesApi : IChangesApi
    {
        public Task<ChangeList> GetMovieChangeListAsync(string end_date, string start_date, int page)
        {
            
        }

        public Task<ChangeList> GetPersonChangeListAsync(string end_date, string start_date, int page)
        {
            
        }

        public Task<ChangeList> GetTVChangeListAsync(string end_date, string start_date, int page)
        {
            
        }
    }
}
