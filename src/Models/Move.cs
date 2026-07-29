namespace ChessGame.Models;

public readonly record struct Move(Position From, Position To)
{
    public bool IsValid =>
        From.IsValid && 
        To.IsValid && 
        From != To;
}