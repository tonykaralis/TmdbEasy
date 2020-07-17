namespace TmdbEasy.Interfaces
{
    public interface IJsonDeserializer
    {
        TmdbEasyModel DeserializeTo<TmdbEasyModel>(string json);
    }
}
