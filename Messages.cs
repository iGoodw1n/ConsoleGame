namespace Game;

public static class Messages
{
    public const string GAME_RULES = "Usage: dotnet run option1 option2 option3...\nMinimum possible options is three. Number of options must be odd.";
    public const string NO_PARAMETERS_ERROR = "Error: There is no parameters with game moves options.";
    public const string PARAMETERS_LESS_MIN_ERROR = "Error: Too little game move options.";
    public const string PARAMETERS_NOT_ODD_ERROR = "Error: Number of game move options must be odd.";
    public const string PARAMETERS_NOT_UNIQUE_ERROR = "Error: Game move options must be unique.";
}
