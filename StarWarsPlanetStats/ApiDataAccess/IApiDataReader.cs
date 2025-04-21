namespace StarWarsPlanetStats.ApiDataAccess
{
    public interface IApiDataReader
    {
        abstract Task<string> Read(string baseAddress, string requestUri);
    }
}