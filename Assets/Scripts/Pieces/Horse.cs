using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }

   /// <summary>
   /// Constructor for the horse class
   /// Sets Height above baord and the Peices name
   /// </summary>
    public Horse() : base()
    {
        CurrentZ = 0.1f;
        Name = PieceType.knight;
    }

    /// <summary>
    /// Method to return all the possible moves the the horse can make when called
    /// </summary>
    /// <returns>MoveType[,] for all possible moves</returns>
    public override MoveType[,] PossibleMove()
    {
        // creates a new rectangular array 8x8 of move type
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
        // returns the array of possible moves 
        return r;

    }

    /// <summary>
    /// Method for setting the move types for each possible move
    /// </summary>
    /// <param name="x">takes a int x position</param>
    /// <param name="y">takes an int y position</param>
    /// <param name="r">ref parameter for the arrays of Movetype</param>
    public void HorseMove(int x, int y, ref MoveType[,] r)
    {
        // instance of a chessman
        ChessMan c;
        // if in the bounds of the board
        if(x >= 0 && x < 8 && y >= 0 && y < 8)
        {
            c = BoardManager.Instance.Chessmans[x, y];
            if (c == null)
                // set the postion to can Move
                r[x, y] = MoveType.canMove;
            else if (isWhite != c.isWhite)
            {
                // sets the the postion in the array to attack
                r[x, y] = MoveType.attack;
            }
        }
    }
}
