namespace ChessGame.Domain;

public sealed class Board
{
    private readonly Piece?[,] _squares = new Piece?[8, 8];

    public Piece? GetPiece(Position position)
    {
        if (!position.IsValid())
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        return _squares[position.File, position.Rank];
    }

    public void PlacePiece(Piece piece, Position position)
    {
        if (!position.IsValid())
        {
            throw new ArgumentOutOfRangeException(nameof(position));
        }

        if (_squares[position.File, position.Rank] is not null)
        {
            throw new InvalidOperationException(
                $"There is already a piece at {position}.");
        }

        _squares[position.File, position.Rank] = piece;
    }
}