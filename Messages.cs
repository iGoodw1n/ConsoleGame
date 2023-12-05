namespace Game;

public static class Messages
{
    public const string GAME_RULES = "Usage: dotnet run move1 move2 move3...\nMinimum possible moves is three. Number of moves must be odd.";
    public const string NO_PARAMETERS_ERROR = "Error: There is no parameters with game moves.";
    public const string PARAMETERS_LESS_MIN_ERROR = "Error: Too little game moves.";
    public const string PARAMETERS_NOT_ODD_ERROR = "Error: Number of game moves must be odd.";
    public const string PARAMETERS_NOT_UNIQUE_ERROR = "Error: Game moves must be unique.";
}
