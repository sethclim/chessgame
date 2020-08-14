using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Pawn : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }

    public Pawn():base()
    {
        CurrentZ = 0.3f;
        Name = PieceType.pawn;
    }

    public override MoveType [,] PossibleMove()
    {
        MoveType[,] r = new MoveType[8, 8];
        ChessMan c, c2;
        int[] e = BoardManager.Instance.EnPassant;

        //White team move
        if (isWhite)
        {
            //Diagonal Left
            if(CurrentX != 0 && CurrentY != 7)
            {
                if (e [0] == CurrentX - 1 && e [1] == CurrentY + 1)
                {
                    r[CurrentX - 1, CurrentY + 1] = MoveType.attack;
                }

                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                    r[CurrentX - 1, CurrentY + 1] = MoveType.attack;
            }
            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 7)
            {
                if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                {
                    r[CurrentX + 1, CurrentY + 1] = MoveType.attack;
                }

                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                    r[CurrentX + 1, CurrentY + 1] = MoveType.attack;
            }
            //Middle
            if(CurrentY != 7)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                if (c == null)
                    r[CurrentX, CurrentY + 1] = MoveType.canMove;
            }
            //Middle on first move
            if(CurrentY == 1)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 2];
                if (c == null && c2 == null)
                    r[CurrentX, CurrentY + 2] = MoveType.canMove;
            }
        }
        else
        {
            //Black pawn
            //Diagonal Left
            if (CurrentX != 0 && CurrentY != 0)
            {
                if (e[0] == CurrentX - 1 && e[1] == CurrentY - 1)
                {
                    r[CurrentX - 1, CurrentY - 1] = MoveType.attack;
                }

                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isWhite)
                    r[CurrentX - 1, CurrentY - 1] = MoveType.attack;
            }
            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 0)
            {
                if (e[0] == CurrentX + 1 && e[1] == CurrentY - 1)
                {
                    r[CurrentX + 1, CurrentY - 1] = MoveType.attack;
                }

                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY - 1];
                if (c != null && c.isWhite)
                    r[CurrentX + 1, CurrentY - 1] = MoveType.attack;
            }
            //Middle
            if (CurrentY != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                if (c == null)
                    r[CurrentX, CurrentY - 1] = MoveType.canMove;
            }
            //Middle on first move
            if (CurrentY == 6)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 2];
                if (c == null && c2 == null)
                    r[CurrentX, CurrentY - 2] = MoveType.canMove;
            }
        }

        return r;
    }
}
