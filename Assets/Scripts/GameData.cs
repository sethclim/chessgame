using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class GameData
{

    int[,] allPieceData = new int[32, 3];

    private bool isWhiteTurn = true;
    List<ChessMan> chessManToSave;
    private void GetData()
    {
    }

<<<<<<< HEAD
    public GameData(BoardManager boardManager)
    {
        isWhiteTurn = boardManager.IsWhiteTurn;
        chessManToSave = boardManager.act;


    }
=======
    //    for (int i = 0; i < activeChessMan.Count; i++)
    //    {
    //        ChessMan chessMan = activeChessMan[i];
    //        allPieceData[i , 0] = (int)chessMan.Name;
    //        allPieceData[i, 1] = chessMan.CurrentX;
    //        allPieceData[i, 2] = chessMan.CurrentY;
    //        int isWhite = 0;
    //        if (chessMan.isWhite)
    //            isWhite = 1;
    //        allPieceData[i, 3] = isWhite;
    //    }
    //}

    //public GameData(BoardManager boardManager)
    //{
    //    isWhiteTurn = boardManager.IsWhiteTurn;
    //    chessManToSave = boardManager.ActiveChessMan;


    //}
>>>>>>> 00b57d5cdc45ffee07ad8b6f08d262308b106e61



}
