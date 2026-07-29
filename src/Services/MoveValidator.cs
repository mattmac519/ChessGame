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

        return piece.IsValidMovement(move.From, move.To);
    }
}