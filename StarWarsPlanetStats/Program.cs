using StarWarsPlanetStats.ApiDataAccess;
using StarWarsPlanetStats.PlanetDataAccess;
using StarWarsPlanetStats.UserInteraction;

try
{
    await new StarWarsPlanetsStatsApp(
        new PlanetsFromApiReader(
            new ApiDataReader(),
            new MockStarWarsApiDataReader()
        ),
        new PlanetStatisticsAnalyzer(
          new ConsoleUserInteractor(),
          new PlanetStatsUserInteractor(new ConsoleUserInteractor())
        ),
        new PlanetStatsUserInteractor(
            new ConsoleUserInteractor()
        )
        ).Run();
}
catch (Exception ex)
{
    Console.WriteLine("Fatal error.", ex);
}
