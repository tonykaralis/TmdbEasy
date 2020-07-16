using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMdbEasy.ApiInterfaces;
using TMdbEasy.TmdbObjects;
using TMdbEasy.TmdbObjects.Collection;
using TMdbEasy.TmdbObjects.Images;
using static TMdbEasy.REngine;

namespace TMdbEasy.ApiObjects
{
    internal class CollectionApi : ICollectionApi
    {
        public async Task<Collections> GetDetailsAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}collection/{id}?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<Collections>(content);
        }

        public async Task<Images> GetImagesAsync(int id, string language = "en")
        {
            var content = await CallApiAsync($"{Url}collection/{id}/images?api_key={ApiKey}&language={language}").ConfigureAwait(false);
            return DeserializeJson<Images>(content);
        }
    }
}
