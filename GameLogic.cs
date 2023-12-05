namespace Game;

public class GameLogic
{
    private string[] _moveOptions;
    public GameLogic(string[] moveOtions)
    {
        _moveOptions = moveOtions;
    }

    public GameResult GetGameResultForUser((string ComputerMove, string UserMove) moves)
    {
        if (IsDraw(moves)) return GameResult.Draw;
        if (IsUserWinner(moves)) return GameResult.Win;
        return GameResult.Lose;
    }

    bool IsUserWinner((string ComputerMove, string UserMove) moves)
    {
        var indexUserMove = Array.IndexOf(_moveOptions, moves.UserMove);
        var indexComputerMove = Array.IndexOf(_moveOptions, moves.ComputerMove);

        var recalculatedUserIndex = (indexUserMove + _moveOptions.Length - indexComputerMove) % _moveOptions.Length;

        return recalculatedUserIndex > 0 &&
            recalculatedUserIndex <= (_moveOptions.Length - 1) / 2;
    }

    bool IsDraw((string ComputerMove, string UserMove) moves)
    {
        return moves.ComputerMove.Equals(moves.UserMove);
    }
}
