using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessMan
{

    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }
    

    public Queen() : base()
    {
        CurrentZ = 0.42f;
        Name = PieceType.queen;
    }
    public override MoveType[,] PossibleMove()
    {
        MoveType[,] r = new MoveType[8, 8];
        ChessMan c;

        int i, j;

        //right
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

        //left
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

        //up
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

        //down
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

        //up-right
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i >= 8||j >= 8)
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

        //up-left
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


        //down-right
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

        //down-left
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