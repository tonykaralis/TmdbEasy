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
    internal class NetworksApi : INetworksApi
    {
        public async Task<Networks> GetDetailsAsync(int id)
        {
            var content = await CallApiAsync($"{Url}review/{id}?api_key={ApiKey}").ConfigureAwait(false);
            return DeserializeJson<Networks>(content);
        }
    }
}
