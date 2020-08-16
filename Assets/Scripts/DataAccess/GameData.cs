using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Game Data Class 
/// represents all info needed for one game
/// </summary>
[Serializable]
public class GameData
{
    //Holds reference to current Game of type GameData
    public static GameData current;
    //date in DateTime
    public DateTime date;
    //List of ChessMan To Be Saved of Type PieceData
    public List<PieceData> chessManToSave = new List<PieceData>();
    // Boolean to store who's turn it is 
    public bool isWhiteTurn = true;

    /// <summary>
    /// Constructor for the GameData class
    /// Sets it's field variables with data from the current state of the board manager
    /// </summary>
    /// <param name="boardManager">Takes current boardmanger at save as type BoardManager</param>
    public GameData(BoardManager boardManager)
    {
        //sets who's turn it is
        isWhiteTurn = boardManager.IsWhiteTurn;
        // Creates a temporary list of all active chess men
        List<ChessMan> activeChessMan = boardManager.ActiveChessMan;
        // Sets the date to the current date
        date = DateTime.Now;
        // loops through all the chess men in active chessman
        foreach (ChessMan chessman in activeChessMan)
        {
            // contructs a new PieceData object out of every chessman
            PieceData pieceData = new PieceData(chessman);
            // adds the piece data to the ChessMan to be saved which will be serialized
            chessManToSave.Add(pieceData);
        }
    }
}
