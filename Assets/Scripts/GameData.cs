using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;


[System.Serializable]
public class GameData
{

    public int[,] allPieceData = new int[33, 4];

    public bool isWhiteTurn = true;
  

    public GameData(BoardManager boardManager)
    {
        isWhiteTurn = boardManager.IsWhiteTurn;
        List<ChessMan>chessManToSave = boardManager.ActiveChessMan;
        
        for (int i = 0; i < chessManToSave.Count; i++)
        {
            ChessMan chessMan = chessManToSave[i];
            allPieceData[i, 0] = (int)chessMan.Name;
            allPieceData[i, 1] = chessMan.CurrentX;
            allPieceData[i, 2] = chessMan.CurrentY;
            int isWhite = 0;
            if (chessMan.isWhite)
                isWhite = 1;
            allPieceData[i, 3] = isWhite;
        }
    }



}
