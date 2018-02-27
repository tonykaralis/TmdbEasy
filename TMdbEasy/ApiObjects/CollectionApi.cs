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
        public CollectionApi() { }

        public async Task<Collections> GetDetailsAsync(int id, string language = "en")
        {
            string query = $"{Url}collection/{id}?api_key={ApiKey}&language={language}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            var collections = DeserializeJson<Collections>(content);
            return collections;
        }

        public async Task<Images> GetImagesAsync(int id, string language = "en")
        {
            string query = $"{Url}collection/{id}/images?api_key={ApiKey}&language={language}";
            var content = await CallApiAsync(query).ConfigureAwait(false);
            var images = DeserializeJson<Images>(content);
            return images;
        }
    }
}
