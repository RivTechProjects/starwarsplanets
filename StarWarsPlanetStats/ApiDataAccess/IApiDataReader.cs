namespace StarWarsPlanetStats.Interfaces
{
    public interface IApiDataReader
    {
        abstract Task<string> Read(string baseAddress, string requestUri);
    }
}