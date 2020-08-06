using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }


    public Rook() : base()
    {
        CurrentZ = 0.42f;                                                                               // Might have to change later
        Name = PieceType.rook;
    }
    public override MoveType[,] PossibleMove()
    {
        MoveType[,] r = new MoveType[8, 8];
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
                r[CurrentX, j] = MoveType.canMove;
                continue;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
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
                r[CurrentX, j] = MoveType.canMove;
                continue;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
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
                r[i, CurrentY] = MoveType.canMove;
                continue;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
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
                r[i, CurrentY] = MoveType.canMove;


            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY] = MoveType.attack;
                    break;
                }
                else
                {
                    break;
                }



            }
        }

        return r;
    }

}
