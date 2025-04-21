public class PlanetStatisticsAnalyzer : IPlanetStatisticsAnalyzer
{
    private readonly IUserInteractor _userInteractor;
    private readonly IPlanetStatsUserInteractor _planetStatsUserInteractor;

    public PlanetStatisticsAnalyzer(
        IUserInteractor userInteractor, 
        IPlanetStatsUserInteractor planetStatsUserInteractor)
    {
        _userInteractor = userInteractor;
        _planetStatsUserInteractor = planetStatsUserInteractor;
    }
    public void Analyze(IEnumerable<Planet> planets)
    {
        var propertyToSelectorMappings = 
            new Dictionary<int, (string PropertyName, Func<Planet, int?> Selector)>
    {
        { 1, ("Population", planet => planet.Population) },
        { 2, ("Diameter", planet => planet.Diameter) },
        { 3, ("Surface Water", planet => planet.SurfaceWater) }
    };

        var choice = _planetStatsUserInteractor.ChooseStatisticsToView(propertyToSelectorMappings);

        if (
            choice.HasValue && 
            propertyToSelectorMappings.TryGetValue(choice.Value, out var selectedProperty))
        {
            ShowStatistics(planets, selectedProperty.PropertyName, selectedProperty.Selector);
        }
        else
        {
            _userInteractor.ShowMessage("No valid statistic selected.");
        }
    }

    private static void ShowStatistics(
    IEnumerable<Planet> planets,
    string propertyName,
    Func<Planet, int?> propertySelector)
    {
        var maxPlanet = planets.MaxBy(propertySelector);
        var minPlanet = planets.MinBy(propertySelector);

        var results = new[]
        {
        ("Max", maxPlanet, propertySelector(maxPlanet)),
        ("Min", minPlanet, propertySelector(minPlanet))
    };

        foreach (var (label, planet, value) in results)
        {
            Console.WriteLine($"{label} {propertyName} is: {value} (planet: {planet.Name})");
        }
    }
}
