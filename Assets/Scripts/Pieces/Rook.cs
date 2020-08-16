using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }

    /// <summary>
    /// Rook constructor 
    /// sets the height and the name of the piece
    /// </summary>
    public Rook() : base()
    {
        CurrentZ = 0.42f;                                                                           
        Name = PieceType.rook;
    }
    /// <summary>
    /// Method to get all possible moves for the rook 
    /// </summary>
    /// <returns>MoveType [,] array of all the possible moves of type MoveType</returns>
    public override MoveType[,] PossibleMove()
    {
        // creates a new rectangular array 8x8 of move type
        MoveType[,] r = new MoveType[8, 8];
        // holds a chess man
        ChessMan c;

        int i, j;

        // Up
        j = CurrentY;
        while (true)
        {
            j++;
            if (j >= 8)
            {
                break;
            }


            c = BoardManager.Instance.Chessmans[CurrentX, j];
            if (c == null)
            {
                // setting th3e position to can move
                r[CurrentX, j] = MoveType.canMove;
                continue;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    // setting th3e position to can attack
                    r[CurrentX, j] = MoveType.attack;
                    break;
                }
                else
                {
                    break;
                }


            }
        }

        // Down
        j = CurrentY;
        while (true)
        {
            j--;
            if (j < 0)
            {
                break;
            }


            c = BoardManager.Instance.Chessmans[CurrentX, j];
            if (c == null)
            {
                // setting th3e position to can move
                r[CurrentX, j] = MoveType.canMove;
                continue;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    // setting th3e position to can attack
                    r[CurrentX, j] = MoveType.attack;
                    break;
                }
                else
                {
                    break;
                }

            }
        }

        //Right
        i = CurrentX;
        while (true)
        {
            i++;
            if (i >= 8)
            {
                break;
            }


            c = BoardManager.Instance.Chessmans[i, CurrentY];
            if (c == null)
            {
                // setting th3e position to can move
                r[i, CurrentY] = MoveType.canMove;
                continue;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    // setting th3e position to can attack
                    r[i, CurrentY] = MoveType.attack;
                    break;
                }
                else
                {
                    break;
                }

            }
        }

        //Left
        i = CurrentX;
        while (true)
        {
            i--;
            if (i < 0)
            {
                break;
            }


            c = BoardManager.Instance.Chessmans[i, CurrentY];
            if (c == null)
            {
                // setting th3e position to can move
                r[i, CurrentY] = MoveType.canMove;


            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    // setting th3e position to can attack
                    r[i, CurrentY] = MoveType.attack;
                    break;
                }
                else
                {
                    break;
                }



            }
        }
        // returns the array of all the possible moves 
        return r;
    }

}
