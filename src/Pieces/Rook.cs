using ChessGame.Models;

namespace ChessGame.Pieces;

public sealed class Rook : Piece
{
    public Rook(PieceColor color) : base(color)
    {
    }

    public override bool IsValidMovement(Position from, Position to)
    {
        if (!from.IsValid || !to.IsValid || from == to)
        {
            return false;
        }

        return from.File == to.File ||
                from.Rank == to.Rank;
    }
}