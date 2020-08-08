using System;

[Serializable]
public class PieceData
{
    public ChessMan.PieceType Name;
    public int CurrentX;
    public int CurrentY;
    public float CurrentZ;
    public bool IsWhite;

    public PieceData(ChessMan chessman)
    {
        Name = chessman.Name;
        CurrentX = chessman.CurrentX;
        CurrentY = chessman.CurrentY;
        CurrentZ = chessman.CurrentZ;
        IsWhite = chessman.isWhite; 
    }
}
