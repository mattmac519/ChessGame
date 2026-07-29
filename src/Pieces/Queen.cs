using ChessGame.Models;

namespace ChessGame.Pieces;

public sealed class Queen : Piece
{
    public Queen(PieceColor color) : base(color)
    {
    }

    public override bool IsValidMovement(Position from, Position to)
    {
        if (!from.IsValid || !to.IsValid || from == to)
        {
            return false;
        }

        int rankDifference = Math.Abs(to.Rank - from.Rank);
        int fileDifference = Math.Abs(to.File - from.File);

        bool isStraight = from.File == to.File ||
                        from.Rank == to.Rank;

        bool isDiagonal = fileDifference == rankDifference;

        return isStraight || isDiagonal;
    }   
}