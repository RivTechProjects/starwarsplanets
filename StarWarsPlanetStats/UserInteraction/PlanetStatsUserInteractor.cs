using StarWarsPlanetStats.Model;
namespace StarWarsPlanetStats.UserInteraction;

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
    Dictionary<int, (string PropertyName, Func<Planet, long?> Selector)> propertyToSelectorMappings)
    {
        _userInteractor.ShowMessage("Which planet stats would you like to see? (Enter -1 to exit)");
        foreach (var kvp in propertyToSelectorMappings)
        {
            _userInteractor.ShowMessage($"{kvp.Key}. {kvp.Value.PropertyName}");
        }

        if (int.TryParse(_userInteractor.ReadFromUser(), out int choice))
        {
            if (choice == -1)
            {
                _userInteractor.ShowMessage("Exiting...");
                return null; // Exit the menu
            }

            if (propertyToSelectorMappings.ContainsKey(choice))
            {
                return choice; // Return the valid choice
            }
        }

        _userInteractor.ShowMessage("Invalid choice. Please try again.");
        return null; // Return null for invalid input
    }

    public void Show(IEnumerable<Planet> planets)
    {
        TablePrinter.Print(planets);
    }
}
