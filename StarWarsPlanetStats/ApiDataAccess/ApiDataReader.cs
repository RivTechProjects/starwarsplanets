namespace StarWarsPlanetStats.ApiDataAccess;

public class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAddress, string requestUri)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = await client.GetAsync(baseAddress);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}