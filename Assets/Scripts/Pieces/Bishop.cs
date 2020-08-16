using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }
    /// <summary>
    /// Constructor for the bishop class]
    /// sets it height and name
    /// </summary>
    public Bishop() : base()
    {
        CurrentZ = 0.42f;   // might have to change later.
        Name = PieceType.bishop;
    }

    /// <summary>
    /// Function for getting all the possible moves of this object
    /// </summary>
    /// <returns> A rectangular array of MoveType</returns>
    public override MoveType[,] PossibleMove()
    {
        // creating a list of MoveType that is 8x8 for the board
        MoveType[,] r = new MoveType[8, 8];
        ChessMan c;

        int i, j;

        // Up-Right 
        //looping in this direction until reaches end of board or finds another piece
        // if its its teams piece stops
        // if not attack is set
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i >= 8 || j >= 8)
            {
                break;
            }


            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                // setting this location to canMove
                r[i, j] = MoveType.canMove;
            }

            else
            {
                if (c.isWhite != isWhite)
                {
                    // setting this location to attack
                    r[i, j] = MoveType.attack;
                    break;
                }
                else
                {
                    break;
                }

            }
        }

        //Up-Left
        //looping in this direction until reaches end of board or finds another piece
        // if its its teams piece stops
        // if not attack is set
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j++;
            if (i < 0 || j >= 8)
            {
                break;
            }


            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                r[i, j] = MoveType.canMove;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = MoveType.attack;
                    break;
                }
                else
                {
                    break;
                }

            }
        }


        //Down-Right
        //looping in this direction until reaches end of board or finds another piece
        // if its its teams piece stops
        // if not attack is set
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j--;
            if (i >= 8 || j < 0)
            {
                break;
            }


            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                r[i, j] = MoveType.canMove;


            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = MoveType.attack;
                    break;
                }
                else
                {
                    break;
                }

            }
        }

        //Down-Left
        //looping in this direction until reaches end of board or finds another piece
        // if its its teams piece stops
        // if not attack is set
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j--;
            if (i < 0 || j < 0)
            {
                break;
            }


            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                r[i, j] = MoveType.canMove;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = MoveType.attack;
                    break;
                }
                else
                {
                    break;
                }

            }
        }

        // return the array of MoveType [,]
        return r;
    }


}
