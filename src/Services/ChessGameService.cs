using ChessGame.Models;

namespace ChessGame.Services;

public sealed class ChessGameService
{
    private readonly MoveValidator _moveValidator;

    public GameState State { get; }

    public ChessGameService(Player whitePlayer, Player blackPlayer)
    {
        _moveValidator = new MoveValidator();

        State = new GameState(whitePlayer, blackPlayer, BoardFactory.CreateStandardBoard());
    }

    public bool TryMove(Move move)
    {
        bool isValid = _moveValidator.IsValidMove(State.Board, move, State.CurrentTurn);

        if (!isValid)
        {
            return false;
        }

        State.Board.MovePiece(move);
        State.SwitchTurn();

        return true;
    }
}