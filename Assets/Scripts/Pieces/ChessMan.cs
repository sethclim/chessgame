using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract Class representing the Generic ChessMan
/// </summary>
public abstract class ChessMan : MonoBehaviour
{
    // Enum for Chess Man holding all move types
    public enum MoveType { noMove, canMove, attack }
    // Enum for ChessMan holding all the types of Pieces
    public enum PieceType { king, queen, bishop, rook, knight, pawn }
    //Setting the Public property for the Name of the Piece
    public PieceType Name { get; set; }
    // Public Property for the chess pieces currentX location
    public int CurrentX { get; set; }
    // Public Property for the chess pieces currentY location
    public int CurrentY { get; set; }
    // Public property for the chess pieces current Z location
    public virtual float CurrentZ { get; set; }

    // Bool to hold if the piece is on the white team or not
    public bool isWhite;

    // Metjod to set the Current X and Y that represents the position of a piece\
    // takes an integer x and y
    public void SetPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    /// <summary>
    /// Virtual method for PossibleMoves
    /// Overriden in each Chess Piece according to their moves
    /// </summary>
    /// <returns> MoveType[,] that holds all the possible moves</returns>
    public virtual MoveType[,] PossibleMove()
    {
        return new MoveType[8, 8];
    }

    /// <summary>
    /// Holds all the possible Kind attack Squares
    /// not fully implemented was for checkmate
    /// </summary>
    /// <returns>bool[,] of all paths that lead to killing king</returns>
    public virtual bool[,] getAttackSquare()
    {
        return new bool[8, 8];
    }

    /// <summary>
    /// method to set the attacks on the king
    /// </summary>
    /// <param name="refAChessMen"></param>
    public virtual void SetAttacks(List<ChessMan> refAChessMen)
    {

    }
}
  
