using static System.Console;

namespace Rock_Paper_Scissors;

static class Program
{
    static void Main()
    {
        while(true)
        {
            Play();
        }
    }

    static void Play()
    {
        var aiHand = GetAiHand();
        var playerHand = GetPlayerHand();
        WriteLine($"Player: {playerHand}");
        WriteLine($"Computer: {aiHand}");
        WriteLine(playerHand.GameStateMessage(aiHand));

        InputPlayAgain();
    }
    static ThrowType GetAiHand() => (ThrowType)Random.Shared.Next(3);

    static ThrowType GetPlayerHand()
    {
        while (true)
        {
            Write("Enter ROCK, PAPER, or SCISSORS: ");

            switch (GetInput())
            {
                case "r" or "rock":
                    return ThrowType.ROCK;
                case "p" or "paper":
                    return ThrowType.PAPER;
                case "s" or "scissors":
                    return ThrowType.SCISSORS;
            }

            WriteLine("Invalid Input");
        }
    }

    static void InputPlayAgain()
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

    static void HandleExit()
    {
        Write("thanks for playing\nPress any key to exit");
        ReadKey();
        Environment.Exit(0);
    }

    static string GetInput() => ReadLine()?.ToLower().Trim() ?? throw new Exception("GetInput result variable returned null");
}