using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }

    public Bishop() : base()
    {
        CurrentZ = 0.42f;                                                                        // might have to change later.
        Name = PieceType.bishop;
    }

    public override MoveType[,] PossibleMove()
    {
        MoveType[,] r = new MoveType[8, 8];
        ChessMan c;

        int i, j;

        // Up-Right
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

        //Up-Left
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


        return r;
    }


}
