using System;

/// <summary>
/// Class the represent the data to be saved for each piece
/// </summary>
[Serializable]
public class PieceData
{
    //Field variables for each pertinent piece of data
    public ChessMan.PieceType Name;
    public int CurrentX;
    public int CurrentY;
    public float CurrentZ;
    public bool IsWhite;

    /// <summary>
    /// Contructor for the piece data class.
    /// Sets all its field variables
    /// </summary>
    /// <param name="chessman">takes a chessman of type Chessman as a parameter</param>
    public PieceData(ChessMan chessman)
    {
        Name = chessman.Name;
        CurrentX = chessman.CurrentX;
        CurrentY = chessman.CurrentY;
        CurrentZ = chessman.CurrentZ;
        IsWhite = chessman.isWhite; 
    }
}
