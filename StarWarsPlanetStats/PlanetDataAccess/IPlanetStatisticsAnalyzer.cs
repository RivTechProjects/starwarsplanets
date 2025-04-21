using StarWarsPlanetStats.Model;
namespace StarWarsPlanetStats.PlanetDataAccess;

public interface IPlanetStatisticsAnalyzer
{
    void Analyze(IEnumerable<Planet> planets);
}
