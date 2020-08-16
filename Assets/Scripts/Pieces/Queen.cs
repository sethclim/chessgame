using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Queen : ChessMan
{
    // sets the base's Current Z
    public override float CurrentZ { get => base.CurrentZ; set => base.CurrentZ = value; }

    private bool[,] attackSquare = new bool[8, 8];
    /// <summary>
    /// Constructor for the queen class.
    /// Sets the height and the name of the Queen
    /// </summary>
    public Queen() : base()
    {
        CurrentZ = 0.42f;
        Name = PieceType.queen;

    }

    /// <summary>
    /// Method to get all possible moves for the Queen 
    /// </summary>
    /// <returns>MoveType [,] array of all the possible moves of type MoveType</returns>
    public override MoveType[,] PossibleMove()
    {
        // creates a new rectangular array 8x8 of move type
        MoveType[,] routes = new MoveType[8, 8];
        // Holds a ChessMan
        ChessMan chessman;

        // int representing the each step in a direction
        int iXpos, jYpos;

        //right
        // setting i to the Current X pos of the piece 
        iXpos = CurrentX;
        // running the loop while true, ends when returned out of
        while (true)
        {
            // incrementing the x pos one each iteration
            iXpos++;
            if (iXpos >= 8)
            {
                // if outta bounds break
                break;
            }

            // getting chessman at this position
            chessman = BoardManager.Instance.Chessmans[iXpos, CurrentY];
            // checking if the chessman is null
            if (chessman == null)
            {
                // if it setting can move 
                routes[iXpos, CurrentY] = MoveType.canMove;
                continue;

            }
            // else there is a piece 
            else
            {
                // if its on the opposite team 
                if (chessman.isWhite != isWhite)
                {
                    // setting can attack
                    routes[iXpos, CurrentY] = MoveType.attack;

                    // checkling if the attacking peice is the king
                    if (chessman.Name == PieceType.king)
                    {
                        // creating a path of true for all squares between Queen and king
                        for (int locx = CurrentX; locx < iXpos; locx++)
                        {
                            attackSquare[locx, CurrentY] = true;
                        }

                    }
                    break;
                }
                else
                {
                    break;
                }

            }
        }

        // Like wise for the rest of the moves 

        //left
        iXpos = CurrentX;
        while (true)
        {
            iXpos--;
            if (iXpos < 0)
            {
                break;
            }


            chessman = BoardManager.Instance.Chessmans[iXpos, CurrentY];
            if (chessman == null)
            {
                routes[iXpos, CurrentY] = MoveType.canMove;


            }
            else
            {
                if (chessman.isWhite != isWhite)
                {
                    routes[iXpos, CurrentY] = MoveType.attack;

                    if (chessman.Name == PieceType.king)
                    {
                        for (int locx = CurrentX; locx < iXpos; locx--)
                        {
                            attackSquare[locx, CurrentY] = true;
                        }

                    }
                    break;
                }
                else
                {
                    break;
                }



            }
        }

        //up
        jYpos = CurrentY;
        while (true)
        {
            jYpos++;
            if (jYpos >= 8)
            {
                break;
            }


            chessman = BoardManager.Instance.Chessmans[CurrentX, jYpos];
            if (chessman == null)
            {
                routes[CurrentX, jYpos] = MoveType.canMove;
                continue;

            }
            else
            {
                if (chessman.isWhite != isWhite)
                {
                    routes[CurrentX, jYpos] = MoveType.attack;

                    if (chessman.Name == PieceType.king)
                    {
                        for (int locy = CurrentY; locy < jYpos; locy++)
                        {
                            attackSquare[CurrentX, locy] = true;
                        }

                    }
                    break;
                }
                else
                {
                    break;
                }


            }
        }

        //down
        jYpos = CurrentY;
        while (true)
        {
            jYpos--;
            if (jYpos < 0)
            {
                break;
            }


            chessman = BoardManager.Instance.Chessmans[CurrentX, jYpos];
            if (chessman == null)
            {
                routes[CurrentX, jYpos] = MoveType.canMove;
                continue;

            }
            else
            {
                if (chessman.isWhite != isWhite)
                {
                    routes[CurrentX, jYpos] = MoveType.attack;

                    if (chessman.Name == PieceType.king)
                    {
                        for (int locy = CurrentY; locy < jYpos; locy--)
                        {
                            attackSquare[CurrentX, locy] = true;
                        }

                    }

                    break;
                }
                else
                {
                    break;
                }

            }
        }

        //up-right
        iXpos = CurrentX;
        jYpos = CurrentY;
        while (true)
        {
            iXpos++;
            jYpos++;
            if (iXpos >= 8 || jYpos >= 8)
            {
                break;
            }


            chessman = BoardManager.Instance.Chessmans[iXpos, jYpos];
            if (chessman == null)
            {
                routes[iXpos, jYpos] = MoveType.canMove;


            }
            else
            {
                if (chessman.isWhite != isWhite)
                {
                    routes[iXpos, jYpos] = MoveType.attack;

                    if (chessman.Name == PieceType.king)
                    {
                        for (int locx = CurrentX; locx < iXpos; locx++)
                        {
                            for (int locy = CurrentY; locy < jYpos; locy++)
                            {
                                attackSquare[locx, locy] = true;
                            }

                        }

                    }


                    break;
                }
                else
                {
                    break;
                }

            }
        }

        //up-left
        iXpos = CurrentX;
        jYpos = CurrentY;
        while (true)
        {
            iXpos--;
            jYpos++;
            if (iXpos < 0 || jYpos >= 8)
            {
                break;
            }


            chessman = BoardManager.Instance.Chessmans[iXpos, jYpos];
            if (chessman == null)
            {
                routes[iXpos, jYpos] = MoveType.canMove;

            }
            else
            {
                if (chessman.isWhite != isWhite)
                {
                    routes[iXpos, jYpos] = MoveType.attack;

                    if (chessman.Name == PieceType.king)
                    {
                        for (int locx = CurrentX; locx < iXpos; locx--)
                        {
                            for (int locy = CurrentY; locy < jYpos; locy++)
                            {
                                attackSquare[locx, locy] = true;
                            }

                        }

                    }
                    break;
                }
                else
                {
                    break;
                }

            }
        }


        //down-right
        iXpos = CurrentX;
        jYpos = CurrentY;
        while (true)
        {
            iXpos++;
            jYpos--;
            if (iXpos >= 8 || jYpos < 0)
            {
                break;
            }


            chessman = BoardManager.Instance.Chessmans[iXpos, jYpos];
            if (chessman == null)
            {
                routes[iXpos, jYpos] = MoveType.canMove;


            }
            else
            {
                if (chessman.isWhite != isWhite)
                {
                    routes[iXpos, jYpos] = MoveType.attack;

                    if (chessman.Name == PieceType.king)
                    {
                        for (int locx = CurrentX; locx < iXpos; locx++)
                        {
                            for (int locy = CurrentY; locy < jYpos; locy--)
                            {
                                attackSquare[locx, locy] = true;
                            }

                        }

                    }

                    break;
                }
                else
                {
                    break;
                }

            }
        }

        //down-left
        iXpos = CurrentX;
        jYpos = CurrentY;
        while (true)
        {
            iXpos--;
            jYpos--;
            if (iXpos < 0 || jYpos < 0)
            {
                break;
            }


            chessman = BoardManager.Instance.Chessmans[iXpos, jYpos];
            if (chessman == null)
            {
                routes[iXpos, jYpos] = MoveType.canMove;

            }
            else
            {
                if (chessman.isWhite != isWhite)
                {
                    routes[iXpos, jYpos] = MoveType.attack;

                    if (chessman.Name == PieceType.king)
                    {
                        for (int locx = CurrentX; locx < iXpos; locx--)
                        {
                            for (int locy = CurrentY; locy > jYpos; locy--)
                            {
                                attackSquare[locx, locy] = true;
                            }

                        }

                    }
                    break;
                }
                else
                {
                    break;
                }

            }
        }


        return routes;
    }

    public override bool[,] getAttackSquare()
    {
        return attackSquare;
    }

}