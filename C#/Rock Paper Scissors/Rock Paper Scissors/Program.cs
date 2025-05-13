using static System.Console;

namespace Rock_Paper_Scissors;

static class Program
{
    static ThrowType GetAiHand() => (ThrowType)Random.Shared.Next(3);

    static ThrowType GetPlayerHand()
    {
        while (true)
        {
            Write("Enter ROCK, PAPER, or SCISSORS: ");
            switch (GetInput())
            {
                case "r" or "rock":
                    return ThrowType.Rock;
                case "p" or "paper":
                    return ThrowType.Paper;
                case "s" or "scissors":
                    return ThrowType.Scissors;
            }

            WriteLine("Invalid Input");
        }
    }

    static bool InputPlayAgain()
    {
        while (true)
        {
            Write("Would you like to play again (Y/N): ");
            switch (GetInput())
            {
                case "y" or "yes":
                    return true;
                case "n" or "no":
                    return false;
            }

            WriteLine("Please enter valid input n/y or no/yes");
        }
    }

    static void Main()
    {
        do
        {
            var aiHand = GetAiHand();
            var playerHand = GetPlayerHand();
            WriteLine("Player: " + playerHand.ToString().ToUpper());
            WriteLine("Computer: " + aiHand.ToString().ToUpper());
            playerHand.CheckGameState(aiHand);
        } while (InputPlayAgain());

        Write("thanks for playing\nPress any key to exit");
        ReadKey();
    }

    static string GetInput() => ReadLine()?.ToLower().Trim() ?? throw new Exception("GetInput result variable returned null");
}