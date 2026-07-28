namespace ChessGame.Domain;

public readonly record struct Position(int File, int Rank)
{
    public bool IsValid()
    {
        return File >= 0 && File < 8 &&
               Rank >= 0 && Rank < 8;
    }

    public override string ToString()
    {
        char fileLetter = (char)('a' + File);
        int rankNumber = Rank + 1;

        return $"{fileLetter}{rankNumber}";
    }
}