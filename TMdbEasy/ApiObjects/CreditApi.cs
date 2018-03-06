using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects;
using static TMdbEasy.REngine;

namespace TMdbEasy.ApiObjects
{
    internal class CreditApi : ICreditApi
    {
        public async Task<Credits> GetDetailsAsync(int id)
        {
            var content = await CallApiAsync($"{Url}credit/{id}?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<Credits>(content);
        }
    }
}
