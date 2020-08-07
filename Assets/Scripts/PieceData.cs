using System;

[Serializable]
public class PieceData
{
    public ChessMan.PieceType Name;
    public int CurrentX;
    public int CurrentY;
    public bool IsWhite;

    public PieceData(ChessMan chessman)
    {
        Name = chessman.Name;
        CurrentX = chessman.CurrentX;
        CurrentY = chessman.CurrentY;
        IsWhite = chessman.isWhite; 
    }
}
