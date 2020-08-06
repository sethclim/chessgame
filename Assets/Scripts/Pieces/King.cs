using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }


    public King() : base()
    {
        CurrentZ = 0.42f;
        Name = PieceType.king;
    }

    public override MoveType[,] PossibleMove()
    {
        MoveType[,] r = new MoveType[8, 8];
        ChessMan c;

        int i, j;

        // Right
        i = CurrentX;

        i++;
        if (i < 8) 
        {
            c = BoardManager.Instance.Chessmans[i, CurrentY];

            if (c == null) 
            {
                r[i, CurrentY] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                r[i, CurrentY] = MoveType.attack;
            }
        }

        // Left
        i = CurrentX;

        i--;
        if (i >= 0)
        {
            c = BoardManager.Instance.Chessmans[i, CurrentY];

            if (c == null)
            {
                r[i, CurrentY] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                r[i, CurrentY] = MoveType.attack;
            }
        }

        // UP
        j = CurrentY;

        j++;
        if (j < 8)
        {
            c = BoardManager.Instance.Chessmans[CurrentX, j];

            if (c == null)
            {
                r[CurrentX, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                r[CurrentX, j] = MoveType.attack;
            }
        }

        // Down
        j = CurrentY;

        j--;
        if (j >= 0)
        {
            c = BoardManager.Instance.Chessmans[CurrentX, j];

            if (c == null)
            {
                r[CurrentX, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                r[CurrentX, j] = MoveType.attack;
            }
        }

        // Up-Right
        i = CurrentX;
        j = CurrentY;

        i++;
        j++;

        if (i < 8 && j < 8)
        {
            c = BoardManager.Instance.Chessmans[i, j];

            if (c == null)
            {
                r[i, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                r[i, j] = MoveType.attack;
            }
        }

        // Up-Left
        i = CurrentX;
        j = CurrentY;

        i++;
        j--;

        if (i < 8 && j >= 0)
        {
            c = BoardManager.Instance.Chessmans[i, j];

            if (c == null)
            {
                r[i, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                r[i, j] = MoveType.attack;
            }
        }

        // Down-Left
        i = CurrentX;
        j = CurrentY;

        i--;
        j--;

        if (i >= 0 && j >= 0)
        {
            c = BoardManager.Instance.Chessmans[i, j];

            if (c == null)
            {
                r[i, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                r[i, j] = MoveType.attack;
            }
        }

        // Down-Right
        i = CurrentX;
        j = CurrentY;

        i--;
        j++;

        if (i >= 0 && j < 8)
        {
            c = BoardManager.Instance.Chessmans[i, j];

            if (c == null)
            {
                r[i, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                r[i, j] = MoveType.attack;
            }
        }

        return r;

    }
}
