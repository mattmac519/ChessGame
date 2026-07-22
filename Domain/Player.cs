namespace ChessGame.Domain;

public sealed class Player
{
    public string Name { get; }
    public PieceColor Color { get; }

    public Player(string name, PieceColor color)
    {
        Name = name;
        Color = color;
    }
}