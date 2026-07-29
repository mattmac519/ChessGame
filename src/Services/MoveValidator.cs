using ChessGame.Models;
using ChessGame.Pieces;

namespace ChessGame.Services;

public sealed class MoveValidator
{
    public bool IsValidMove(Board board, Move move, PieceColor currentTurn)
    {
        if (!move.IsValid)
        {
            return false;
        }

        Piece? piece = board.GetPiece(move.From);

        if (piece is null)
        {
            return false;
        }

        if (piece.Color != currentTurn)
        {
            return false;
        }

        Piece? targetPiece = board.GetPiece(move.To);

        if (targetPiece?.Color == piece.Color)
        {
            return false;
        }

        if (!piece.IsValidMovement(move.From, move.To))
        {
            return false;
        }

        if (piece is Knight)
        {
            return true;
        }

        return IsPathClear(board, move);
    }

    private static bool IsPathClear(Board board, Move move)
    {
        int fileStep = Math.Sign(move.To.File - move.From.File);
        int rankStep = Math.Sign(move.To.Rank - move.From.Rank);

        var current = new Position(move.From.File + fileStep, move.From.Rank + rankStep);

        while (current != move.To)
        {
            if (board.GetPiece(current) is not null)
            {
                return false;
            }

            current = new Position(current.File + fileStep, current.Rank + rankStep);
        }

        return true;
    }
}