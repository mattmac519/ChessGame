using ChessGame.Pieces;

namespace ChessGame.Models;

public sealed class Board
{
    private readonly Piece?[,] _squares = new Piece?[8, 8];

    public Piece? GetPiece(Position position)
    {
        if (!position.IsValid)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        return _squares[position.File, position.Rank];
    }

    public void PlacePiece(Piece piece, Position position)
    {
        if (!position.IsValid)
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        if (_squares[position.File, position.Rank] is not null)
        {
            throw new InvalidOperationException(
                $"A piece already occupies {position}.");
        }

        _squares[position.File, position.Rank] = piece;
    }

    public Piece? MovePiece(Move move)
    {
        if (!move.IsValid)
        {
            throw new ArgumentException(
                "The move contains invalid positions.", 
                nameof(move));
        }

        Piece? movingPiece = GetPiece(move.From);

        if (movingPiece is null)
        {
            throw new InvalidOperationException(
                $"There is no piece at {move.From}.");
        }

        Piece? capturedPiece = GetPiece(move.To);

        if (capturedPiece?.Color == movingPiece.Color)
        {
            throw new InvalidOperationException(
                "A piece cannot capture another piece of the same color.");
        }

        _squares[move.To.File, move.To.Rank] = movingPiece;
        _squares[move.From.File, move.From.Rank] = null;

        movingPiece.MarkAsMoved();

        return capturedPiece;
        
    }
}