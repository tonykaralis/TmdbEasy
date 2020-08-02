using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;
using TmdbEasy.Interfaces;

[assembly: InternalsVisibleTo("TmdbEasy.Tests.Unit")]
namespace TmdbEasy
{
    internal class NewtonSoftDeserializer : IJsonDeserializer
    {
        public TmdbEasyModel DeserializeTo<TmdbEasyModel>(string json)
        {
            if (string.IsNullOrEmpty(json) || string.IsNullOrWhiteSpace(json))
                throw new ArgumentNullException("Cannot deserialize null or empty json value");

            return JsonConvert.DeserializeObject<TmdbEasyModel>(json);
        }
    }
}
