using Newtonsoft.Json;
using System;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class NewtonSoftDeserializer : IJsonDeserializer
    {
        public TmdbEasyModel DeserializeTo<TmdbEasyModel>(string json)
        {
            if (string.IsNullOrEmpty(json) || string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException("Cannot deserialize null or empty json value");

            return JsonConvert.DeserializeObject<TmdbEasyModel>(json);
        }
    }
}
