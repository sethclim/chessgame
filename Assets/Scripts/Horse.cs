using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }

    public Horse() : base()
    {
        CurrentZ = 0.3f;
    }

    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8, 8];

        //up left
        HorseMove(CurrentX - 1, CurrentY + 2, ref r);

        //up right
        HorseMove(CurrentX + 1, CurrentY + 2, ref r);

        //RightUp
        HorseMove(CurrentX + 2, CurrentY + 1, ref r);

        //RightDown
        HorseMove(CurrentX + 2, CurrentY - 1, ref r);

        //Down left
        HorseMove(CurrentX - 1, CurrentY - 2, ref r);

        //Down right
        HorseMove(CurrentX + 1, CurrentY - 2, ref r);

        //LeftUp
        HorseMove(CurrentX - 2, CurrentY + 1, ref r);

        //LeftDown
        HorseMove(CurrentX - 2, CurrentY - 1, ref r);
        return r;

    }

    public void HorseMove(int x, int y, ref bool[,] r)
    {
        ChessMan c;
        if(x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            c = BoardManager.Instance.Chessmans[x, y];
            if (c == null)
                r[x, y] = true;
            else if (isWhite != c.isWhite)
            {
                r[x, y] = true;
            }
        }
    }
}
