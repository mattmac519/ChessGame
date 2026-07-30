namespace ChessGame.Models;

public sealed class GameState
{
    public Board Board { get; }
    public Player WhitePlayer { get; }
    public Player BlackPlayer { get; }
    public PieceColor CurrentTurn { get; private set; }
    public GameStatus Status { get; private set; }

    public GameState(Player whitePlayer, Player blackPlayer)
    {
        if (whitePlayer.Color != PieceColor.White)
        {
            throw new ArgumentException(
                "The white player must use white pieces.",
                nameof(whitePlayer));
        }

        if (blackPlayer.Color != PieceColor.Black)
        {
            throw new ArgumentException(
                "The black player must use black pieces.",
                nameof(blackPlayer));
        }

        Board = new Board();
        WhitePlayer = whitePlayer;
        BlackPlayer = blackPlayer;
        CurrentTurn = PieceColor.White;
        Status = GameStatus.InProgress;
    }

    public void SwitchTurn()
    {
        CurrentTurn = CurrentTurn == PieceColor.White
            ? PieceColor.Black
            : PieceColor.White;
    }
}