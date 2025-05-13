namespace Rock_Paper_Scissors;

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
