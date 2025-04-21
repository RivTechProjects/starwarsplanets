public class PlanetStatsUserInteractor : IPlanetStatsUserInteractor
{
    private readonly IUserInteractor _userInteractor;

    public PlanetStatsUserInteractor(
        IUserInteractor userInteractor
    )
    {
        _userInteractor = userInteractor;
    }

    public int? ChooseStatisticsToView(
        Dictionary
        <int,
        (string PropertyName,
        Func<Planet, int?> Selector)> propertyToSelectorMappings)
    {
        _userInteractor.ShowMessage("Which planet stats would you like to see?");
        foreach (var kvp in propertyToSelectorMappings)
        {
            _userInteractor.ShowMessage($"{kvp.Key}. {kvp.Value.PropertyName}");
        }

        if (int.TryParse(_userInteractor.ReadFromUser(), out int choice) && propertyToSelectorMappings.ContainsKey(choice))
        {
            return choice;
        }

        _userInteractor.ShowMessage("Invalid choice.");
        return null;
    }

    public void Show(IEnumerable<Planet> planets)
    {
        foreach (var planet in planets)
        {
            _userInteractor.ShowMessage(
                $"Name: {planet.Name}, Population: {planet.Population}, Diameter: {planet.Diameter}, Surface Water: {planet.SurfaceWater}");
        }
    }
}
