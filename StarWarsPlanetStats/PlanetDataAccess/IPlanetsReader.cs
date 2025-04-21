using StarWarsPlanetStats.Model;
namespace StarWarsPlanetStats.PlanetDataAccess;

public interface IPlanetsReader
{
    Task<IEnumerable<Planet>> Read();
}
