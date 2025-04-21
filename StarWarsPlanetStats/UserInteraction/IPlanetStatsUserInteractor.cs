using StarWarsPlanetStats.Model;
namespace StarWarsPlanetStats.UserInteraction;

public interface IPlanetStatsUserInteractor
{
    void Show(IEnumerable<Planet> planets);
    int? ChooseStatisticsToView(
        Dictionary<int, (string PropertyName, Func<Planet, long?> Selector)> propertyToSelectorMappings);
}
