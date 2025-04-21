public interface IPlanetStatsUserInteractor
{
    void Show(IEnumerable<Planet> planets);
    int? ChooseStatisticsToView(
        Dictionary<int, (string PropertyName, Func<Planet, int?> Selector)> propertyToSelectorMappings);
}
