using ChessGame.Models;

namespace ChessGame.Pieces;

public abstract class Piece
{
    public PieceColor Color { get; }
    public bool HasMoved { get; private set; }

    protected Piece(PieceColor color)
    {
        Color = color;
        HasMoved = false;
    }

    public void MarkAsMoved()
    {
        HasMoved = true;
    }
}