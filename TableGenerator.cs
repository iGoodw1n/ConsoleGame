using ConsoleTableExt;

namespace Game;

public static class TableGenerator
{
    public static void PrintTable(string[] moves, GameLogic gameLogic)
    {
        var headerRow = new List<string>() { " v PC\\User >" };
        headerRow.AddRange(moves);

        var tableData = new List<List<object>>
        {
           headerRow.Select(x => (object)x).ToList()
        };

        foreach (var compMove in moves)
        {
            var row = new List<object> { compMove };

            foreach (var userMove in moves)
            {
                var userResult = gameLogic.GetGameResultForUser((compMove, userMove));
                userResult = char.ToUpper(userResult[0]) + userResult.Substring(1);
                row.Add(userResult);
            }
            tableData.Add(row);
        }

        ConsoleTableBuilder
            .From(tableData)
            .WithFormat(ConsoleTableBuilderFormat.Alternative)
            .ExportAndWriteLine();
    }
}
