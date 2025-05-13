namespace Rock_Paper_Scissors;

public static class ThrowTypeExtensions
{
    public static string GameStateMessage(this ThrowType player, ThrowType computer) =>
        player == computer ? "It's a draw" :
        player.IsBeatenBy() == computer ? "You lose" :
        "You win";

    private static ThrowType IsBeatenBy(this ThrowType throwType) =>
        throwType == ThrowType.ROCK ? ThrowType.PAPER :
        throwType == ThrowType.PAPER ? ThrowType.SCISSORS :
        ThrowType.ROCK;
}
