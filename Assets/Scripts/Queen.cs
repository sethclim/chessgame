using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessMan
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];
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
                r[i, CurrentY] = true;
                continue;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY] = true;
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
                r[i, CurrentY] = true;
                break;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY] = true;
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
                r[CurrentX, j] = true;
                continue;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, j] = true;
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
                r[CurrentX, j] = true;
                continue;

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, j] = true;
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
                r[i, j] = true;
          

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = true;
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
                r[i, j] = true;
                            
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = true;
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
                r[i, j] = true;
               

            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = true;
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
                r[i, j] = true;
        
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = true;
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