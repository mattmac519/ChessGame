using ChessGame.Models;
using ChessGame.Pieces;

namespace ChessGame.Services;

public static class BoardFactory
{
    public static Board CreateStandardBoard()
    {
        var board = new Board();

        Piece[] whiteBackRank = CreateBackRank(PieceColor.White);
        Piece[] blackBackRank = CreateBackRank(PieceColor.Black);

        for (int file = 0; file < 8; file++)
        {
            board.PlacePiece(whiteBackRank[file], new Position(file, 0));
            board.PlacePiece(new Pawn(PieceColor.White), new Position(file, 1));

            board.PlacePiece(blackBackRank[file], new Position(file, 7));
            board.PlacePiece(new Pawn(PieceColor.Black), new Position(file, 6));
        }

        return board;
    }

    private static Piece[] CreateBackRank(PieceColor color)
    {
        return
        [
            new Rook(color),
            new Knight(color),
            new Bishop(color),
            new Queen(color),
            new King(color),
            new Bishop(color),
            new Knight(color),
            new Rook(color)
        ];
    }

}