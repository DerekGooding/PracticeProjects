namespace Rock_Paper_Scissors;

public enum ThrowType
{
    Rock,
    Paper,
    Scissors
}

public enum GameState
{
    Win,
    Lose,
    Draw
}

public static class ThrowTypeExtensions
{
    public static GameState CheckGameState(this ThrowType player, ThrowType computer) =>
        player == computer ? GameState.Draw :
        player.IsBeatenBy() == computer ? GameState.Lose :
        GameState.Win;

    private static ThrowType IsBeatenBy(this ThrowType throwType) =>
        throwType == ThrowType.Rock ? ThrowType.Paper :
        throwType == ThrowType.Paper ? ThrowType.Scissors :
        ThrowType.Rock;
}

static class Program
{
    static ThrowType GetAiHand() => (ThrowType)Random.Shared.Next(3);

    static ThrowType GetPlayerHand()
    {
        while (true)
        {
            Console.Write("Enter ROCK, PAPER, or SCISSORS: ");
            switch (GetInput())
            {
                case "rock":
                case "r":
                    return ThrowType.Rock;
                case "paper":
                case "p":
                    return ThrowType.Paper;
                case "scissors":
                case "s":
                    return ThrowType.Scissors;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }

    static bool InputPlayAgain()
    {
        while (true)
        {
            Console.Write("Would you like to play again (Y/N): ");
            switch (GetInput())
            {
                case "y":
                case"yes":
                    return true;
                case "n":
                case "no":
                    Console.Write("thanks for playing");
                    return false;
            }

            Console.WriteLine("Please enter valid input n/y or no/yes");
        }
    }

    static void Main()
    {
        do
        {
            var aiHand = GetAiHand();
            var playerHand = GetPlayerHand();
            Console.WriteLine("Player: " + playerHand.ToString().ToUpper());
            Console.WriteLine("Computer: " + aiHand.ToString().ToUpper());
            playerHand.CheckGameState(aiHand);
        } while (InputPlayAgain());
    }

    static string GetInput() => Console.ReadLine()?.ToLower().Trim() ?? throw new Exception("GetInput result variable returned null");
}