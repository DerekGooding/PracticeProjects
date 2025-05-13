using static System.Console;

namespace Rock_Paper_Scissors;

public class Game
{
    private record struct ThrowChoice(ThrowType ThrowType, string[] Inputs);

    private readonly ThrowChoice[] _choices =
    [
        new(ThrowType.ROCK, ["rock", "r"]),
        new(ThrowType.PAPER, ["paper", "p"]),
        new(ThrowType.SCISSORS, ["scissors", "s"]),
    ];

    public void Play()
    {
        while (true)
        {
            var aiHand = GetAiHand();
            var playerHand = GetPlayerHand();
            WriteLine($"Player: {playerHand}");
            WriteLine($"Computer: {aiHand}");
            WriteLine(playerHand.GameStateMessage(aiHand));

            InputPlayAgain();
        }
    }

    private static ThrowType GetAiHand() => (ThrowType)Random.Shared.Next(3);

    private ThrowType GetPlayerHand()
    {
        while (true)
        {
            Write("Enter ROCK, PAPER, or SCISSORS: ");

            var result = GetInput();

            if (_choices.Any(c => c.Inputs.Contains(result)))
                return _choices.First(c => c.Inputs.Contains(result)).ThrowType;

            WriteLine("Invalid Input");
        }
    }

    private static void InputPlayAgain()
    {
        while (true)
        {
            Write("Would you like to play again (Y/N): ");

            var input = GetInput();
            if (input is "y" or "yes")
                return;
            if (input is "n" or "no")
                HandleExit();

            WriteLine("Please enter valid input n/y or no/yes");
        }
    }

    private static void HandleExit()
    {
        Write("thanks for playing\nPress any key to exit");
        ReadKey();
        Environment.Exit(0);
    }

    private static string GetInput() => ReadLine()?.ToLower().Trim() ?? throw new Exception("GetInput result variable returned null");
}
