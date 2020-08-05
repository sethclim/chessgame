using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }

    public Horse() : base()
    {
        CurrentZ = 0.1f;
    }

    public override MoveType[,] PossibleMove()
    {
        MoveType[,] r = new MoveType[8, 8];

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

    public void HorseMove(int x, int y, ref MoveType[,] r)
    {
        ChessMan c;
        if(x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            c = BoardManager.Instance.Chessmans[x, y];
            if (c == null)
                r[x, y] = MoveType.canMove;
            else if (isWhite != c.isWhite)
            {
                r[x, y] = MoveType.attack;
            }
        }
    }
}
