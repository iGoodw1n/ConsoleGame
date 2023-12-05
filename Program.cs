using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;

namespace Game;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            CheckParameters(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(Messages.GAME_RULES);
            return;
        }
        var computerMove = args[Random.Shared.Next(0, args.Length)];
        var keyBytes = HMACService.GenerateHMACKey(keyLengthBytes: 32);
        var signedComputerMove = HMACService.SignComputerMove(keyBytes, computerMove);
        Console.WriteLine("HMAC: " + signedComputerMove);
        PrintMenu(args);
        var gameLogic = new GameLogic(args);
        HandleUserInput(args, gameLogic, computerMove);

        var key = BitConverter.ToString(keyBytes).Replace("-", "");
        Console.WriteLine($"HMAC Key: {key}");
    }



    static void CheckParameters(string[] args)
    {
        if (args.Length == 0)
        {
            throw new ArgumentException(Messages.NO_PARAMETERS_ERROR);
        }

        if (args.Length < 3)
        {
            throw new ArgumentException(Messages.PARAMETERS_LESS_MIN_ERROR);
        }

        if (args.Length % 2 == 0)
        {
            throw new ArgumentException(Messages.PARAMETERS_NOT_ODD_ERROR);
        }

        if (args.Distinct().Count() != args.Length)
        {
            throw new ArgumentException(Messages.PARAMETERS_NOT_UNIQUE_ERROR);
        }
    }

    static void PrintMenu(string[] gameOptions)
    {
        Console.WriteLine("Available moves:");

        for (int i = 0; i < gameOptions.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {gameOptions[i]}");
        }
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
    }

    static void HandleUserInput(string[] moves, GameLogic gameLogic, string computerMove)
    {
        while (true)
        {
            Console.Write("Enter your move: ");
            var input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            var inputAsInt = input - '0';

            if (inputAsInt == 0)
            {
                Environment.Exit(0);
            }

            if (inputAsInt > 0 && inputAsInt < moves.Length)
            {
                PrintResultOfGame(moves[inputAsInt - 1], computerMove, gameLogic);
                break;
            }

            if (input == '?')
            {
                TableGenerator.PrintTable(moves, gameLogic);
            }
            else
            {
                Console.WriteLine("Incorrect input. Try again.");
            }
        }
    }

    private static void PrintResultOfGame(string userMove, string computerMove, GameLogic gameLogic)
    {
        Console.WriteLine($"Your move: {userMove}");
        Console.WriteLine($"Computer move: {computerMove}");
        var result = gameLogic.GetGameResultForUser((computerMove, userMove));
        Console.WriteLine(result);
    }
}

