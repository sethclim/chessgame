using System.Collections;
using System.Collections.Generic;

using System;


[Serializable]
public class GameData
{
    public static GameData current;
    public DateTime date;
    public List<PieceData> chessManToSave = new List<PieceData>();
    public bool isWhiteTurn = true;

    public GameData(BoardManager boardManager)
    {
        isWhiteTurn = boardManager.IsWhiteTurn;
        List<ChessMan> activeChessMan = boardManager.ActiveChessMan;
        date = DateTime.Now;
        foreach (ChessMan chessman in activeChessMan)
        {
            PieceData pieceData = new PieceData(chessman);
            chessManToSave.Add(pieceData);
        }
    }
}
