namespace TmdbEasy.Interfaces
{
    public interface IApiFactory
    {
        TApi GetApi<TApi>();
    }
}
