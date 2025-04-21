using StarWarsPlanetStats.PlanetDataAccess;
using StarWarsPlanetStats.UserInteraction;

public class StarWarsPlanetsStatsApp
{
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetStatisticsAnalyzer _planetStatisticsAnalyzer;
    private readonly IPlanetStatsUserInteractor _planetStatsUserInteractor;

    public StarWarsPlanetsStatsApp(
        IPlanetsReader planetsReader,
        IPlanetStatisticsAnalyzer planetStatisticsAnalyzer,
        IPlanetStatsUserInteractor planetStatsUserInteractor)
    {
        _planetsReader = planetsReader;
        _planetStatisticsAnalyzer = planetStatisticsAnalyzer;
        _planetStatsUserInteractor = planetStatsUserInteractor;
    }

    public async Task Run()
    {
        var planets = await _planetsReader.Read();

        _planetStatsUserInteractor.Show(planets);

        _planetStatisticsAnalyzer.Analyze(planets);
    }
}
