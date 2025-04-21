namespace StarWarsPlanetStats.UserInteraction;

public interface IUserInteractor
{
    void ShowMessage(string message);
    string? ReadFromUser();
}
