namespace ChessGame.Models;

public sealed class Player
{
    public string Name { get; }
    public PieceColor Color { get; }

    public Player(string name, PieceColor color)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "A player must have a name.",
                nameof(name));
        }

        Name = name;
        Color = color;
    }
}