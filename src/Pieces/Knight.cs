using ChessGame.Models;

namespace ChessGame.Pieces;

public sealed class Knight : Piece
{
    public Knight(PieceColor color) : base(color)
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

        return (fileDifference == 2 && rankDifference == 1) ||
               (fileDifference == 1 && rankDifference == 2);
    }
}