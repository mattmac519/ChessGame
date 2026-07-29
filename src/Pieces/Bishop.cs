using ChessGame.Models;

namespace ChessGame.Pieces;

public sealed class Bishop : Piece
{
    public Bishop(PieceColor color) : base(color)
    {
    }

    public override bool IsValidMovement(Position from, Position to)
    {
        if (!from.IsValid || !to.IsValid || from == to)
        {
            return false;
        }

        int fileDifference = Math.Abs(to.File - from.File);
        int rankDifference = Math.Abs(to.Rank - from.Rank);

        return fileDifference == rankDifference;
    }
}