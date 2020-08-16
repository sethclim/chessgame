using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pawn : ChessMan
{
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }

    /// <summary>
    /// Constructor for the Pawn Class
    /// Sets the height above the board
    /// Sets the name pf the peice to pawn 
    /// </summary>
    public Pawn():base()
    {
        CurrentZ = 0.3f;
        Name = PieceType.pawn;
    }

    /// <summary>
    /// Method to get all possible moves for the pawn 
    /// </summary>
    /// <returns>MoveType [,] array of all the possible moves of type MoveType</returns>
    public override MoveType [,] PossibleMove()
    {
        // creates a new rectangular array 8x8 of move type
        MoveType[,] r = new MoveType[8, 8];
        // Variables to hold to chessman
        ChessMan c, c2;
        // array of ints for EnPassant functionality
        int[] e = BoardManager.Instance.EnPassant;

        //White team move
        if (isWhite)
        {
            //Diagonal Left
            if(CurrentX != 0 && CurrentY != 7)
            {
                // checking for Enpassent attack
                if (e [0] == CurrentX - 1 && e [1] == CurrentY + 1)
                {
                    r[CurrentX - 1, CurrentY + 1] = MoveType.attack;
                }

                // checking for normal attack
                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                    r[CurrentX - 1, CurrentY + 1] = MoveType.attack;
            }
            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 7)
            {
                // checking for Enpassent attack
                if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                {
                    r[CurrentX + 1, CurrentY + 1] = MoveType.attack;
                }

                // checking for normal attack
                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                    r[CurrentX + 1, CurrentY + 1] = MoveType.attack;
            }
            //Middle
            if(CurrentY != 7)
            {
                // normal move forward one square
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                if (c == null)
                    r[CurrentX, CurrentY + 1] = MoveType.canMove;
            }
            //Middle on first move
            // if first move
            if(CurrentY == 1)
            {
                // checking for move forward one or two squares
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 2];
                if (c == null && c2 == null)
                    r[CurrentX, CurrentY + 2] = MoveType.canMove;
            }
        }
        // black team move
        else
        {
            //Black pawn
            //Diagonal Left
            if (CurrentX != 0 && CurrentY != 0)
            {
                // checking for Enpassent attack
                if (e[0] == CurrentX - 1 && e[1] == CurrentY - 1)
                {
                    r[CurrentX - 1, CurrentY - 1] = MoveType.attack;
                }
                // checking for normal attack
                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isWhite)
                    r[CurrentX - 1, CurrentY - 1] = MoveType.attack;
            }
            //Diagonal Right
            if (CurrentX != 7 && CurrentY != 0)
            {
                // checking for Enpassent attack
                if (e[0] == CurrentX + 1 && e[1] == CurrentY - 1)
                {
                    r[CurrentX + 1, CurrentY - 1] = MoveType.attack;
                }
                // checking for normal attack
                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY - 1];
                if (c != null && c.isWhite)
                    r[CurrentX + 1, CurrentY - 1] = MoveType.attack;
            }
            //Middle
            if (CurrentY != 0)
            {
                // normal move forward one square
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                if (c == null)
                    r[CurrentX, CurrentY - 1] = MoveType.canMove;
            }
            //Middle on first move
            // if first move 
            if (CurrentY == 6)
            {
                // checking for move forward one or two squares
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 2];
                if (c == null && c2 == null)
                    r[CurrentX, CurrentY - 2] = MoveType.canMove;
            }
        }

        return r;
    }
}
