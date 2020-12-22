using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class King : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }

    /// <summary>
    /// Constructor for king class
    /// sets the height and name of the piece
    /// </summary>
    public King() : base()
    {
        CurrentZ = 0.42f;
        Name = PieceType.king;
        
    }



    /// <summary>
    /// Method to return all the possible moves the the kind can make when called
    /// Sets its array to either can move or attack
    /// if not set stays at no move
    /// </summary>
    /// <returns>MoveType[,] for all possible moves</returns>
    public override MoveType[,] PossibleMove()
    {
        // creates a new rectangular array 8x8 of move type
        MoveType[,] r = new MoveType[8, 8];

        // holds a chessmans
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
                // set position to can move
                r[i, CurrentY] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                // set position to can attack
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
                // set position to can move
                r[i, CurrentY] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                // set position to can attack
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
                // set position to can move
                r[CurrentX, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                // set position to can attack
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
                // set position to can move
                r[CurrentX, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                // set position to can attack
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
                // set position to can move
                r[i, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                // set position to can attack
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
                // set position to can move
                r[i, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                // set position to can attack
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
                // set position to can moves
                r[i, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                // set position to can attack
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
                // set position to can move
                r[i, j] = MoveType.canMove;
            }
            else if (c.isWhite != isWhite)
            {
                // set position to can attack
                r[i, j] = MoveType.attack;
            }
        }

        // returns an array of all the possible moves the king can make
        return r;

    }

}
