using System.Text.Json;
using StarWarsPlanetStats.ApiDataAccess;
using StarWarsPlanetStats.DTOs;
using StarWarsPlanetStats.Model;
namespace StarWarsPlanetStats.PlanetDataAccess;

public class PlanetsFromApiReader : IPlanetsReader
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _mockApiDataReader;

    public PlanetsFromApiReader(
        IApiDataReader apiDataReader,
        IApiDataReader mockApiDataReader)
    {
        _apiDataReader = apiDataReader;
        _mockApiDataReader = mockApiDataReader;
    }


    public async Task<IEnumerable<Planet>> Read()
    {
        var baseAddress = "https://swapi.dev/";
        var requestUri = "api/planets";
        string? json = null;

        try
        {
            json = await _apiDataReader.Read(baseAddress, requestUri);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("SWAPI has failed.", ex);
            Console.WriteLine("Using mock data instead...");
            Console.WriteLine(new string('-', 64));
        }

        if (json is null)
        {
            try
            {
                json = await _mockApiDataReader.Read(baseAddress, requestUri);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Failed.", ex);
            }
        }

        var root = JsonSerializer.Deserialize<Root>(json ?? "{}");

        return ToPlanets(root);
    }

    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }

        return root.results.Select(
            planetDto => (Planet)planetDto);
    }
}