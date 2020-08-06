using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessMan : MonoBehaviour
{
    public enum MoveType {noMove, canMove, attack}
    public enum PieceType { pawn, queen, king, bishop, rook, knight }
    public PieceType Name { get; set; }
    public int CurrentX { get; set; }
    public int CurrentY { get; set; }
    public virtual float CurrentZ { get; set; }

    public bool isWhite;

    public void SetPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    public virtual MoveType[,] PossibleMove()
    {
        return new MoveType[8,8];
    }

   
}
