using ChessGame.Models;

namespace ChessGame.Pieces;

public sealed class Pawn : Piece
{
    public Pawn(PieceColor color) : base(color)
    {
    }

    public override bool IsValidMovement(Position from, Position to)
    {
        if (!from.IsValid || !to.IsValid || to == from)
        {
            return false;
        }

        int direction = Color == PieceColor.White ? 1 : -1;
        int startingRank = Color == PieceColor.White ? 1 : 6;

        int fileDifference = Math.Abs(to.File - from.File);
        int rankDifference = to.Rank - from.Rank;

        bool oneSquare = fileDifference == 0 && 
                         rankDifference == direction;

        bool twoSquares = fileDifference == 0 && 
                          rankDifference == 2 * direction &&
                          from.Rank == startingRank &&
                          !HasMoved;

        bool capture = fileDifference == 1 &&
                       rankDifference == 1 * direction;

        return oneSquare || twoSquares || capture;
                        
    }
}