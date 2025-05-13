namespace Rock_Paper_Scissors;

public static class ThrowTypeExtensions
{
    public static string GameStateMessage(this ThrowType player, ThrowType computer) =>
        player == computer ? "It's a draw" :
        player.IsBeatenBy() == computer ? "You lose" :
        "You win";

    private static ThrowType IsBeatenBy(this ThrowType throwType) =>
        throwType == ThrowType.Rock ? ThrowType.Paper :
        throwType == ThrowType.Paper ? ThrowType.Scissors :
        ThrowType.Rock;
}
