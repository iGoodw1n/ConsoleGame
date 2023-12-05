namespace Game;

public class GameLogic
{
    private string[] _moveOptions;
    public GameLogic(string[] moveOtions)
    {
        _moveOptions = moveOtions;
    }

    public string GetGameResultForUser((string ComputerMove, string UserMove) moves)
    {
        if (IsDraw(moves)) return "Draw";
        if (IsUserWinner(moves)) return "Win";
        return "Lose";
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
