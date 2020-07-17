using Newtonsoft.Json;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class NewtonSoftDeserializer : IJsonDeserializer
    {
        public TmdbEasyModel DeserializeTo<TmdbEasyModel>(string json)
        {
            return JsonConvert.DeserializeObject<TmdbEasyModel>(json);
        }
    }
}
