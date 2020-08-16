using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //Getter setter to a static instance of the Boardmanager
    public static BoardManager Instance { get; set; }
    // Stores allowed Moves
    private ChessMan.MoveType[,] allowedMoves { set; get; }
    // Array of Chessmes
    public ChessMan[,] Chessmans { set; get; }
    // Holds the currently selected ChessMan
    private ChessMan selectedChessMan;

    //Holds reference to the camswitcher Object
    public CamSwitcher camSwitcherObj;

    //constants for the tiles
    private const float tile_Size = 1.0f;
    private const float tile_OffSet = 0.5f;

    //Getters and Setters the X and Y Selection Updated every time selection changes
    public int SelectionX { get; set; } = -1;
    public int SelectionY { get; set; } = -1;

    // Quaternion to set the orientation of each peice in 3D space
    private readonly Quaternion orientation = Quaternion.Euler(-90, -90, 0);

    // array of int for the EnPassant move the pawn has
    public int[] EnPassant { get; set; }

    // Bool for who's turn it is.  Has a private set, defaulted to white
    public bool IsWhiteTurn { get; private set; } = true;
    // Stores if the selection has changed
    public bool selectionChanged = false;

    // List of all the ChessMan Prefabs
    public List<ChessMan> chessmanPrefabs;
    // List of the Active ChessMan has a private set 
    public List<ChessMan> ActiveChessMan { get; private set; }

    // Holds an instance of the board
    public Board currentBoard;

    /// <summary>
    /// Start method of the baord manager
    /// </summary>
    private void Start()
    {
        //sets Instance to the boardmanager
        Instance = this;
        // instantiates the Camswiter Object
        camSwitcherObj = Instantiate(camSwitcherObj);
        // calls the set camera method to begin ion corrent location
        camSwitcherObj.SetCameras();
        // Calls spawn all chessman
        SpawnAllChessMan();
    }
    // Update listens for selection changed 
    // either selects a chessman or moves it
    private void Update()
    {
        if (selectionChanged)
        {
            if (selectedChessMan == null)
            {
                //select the chessman
                SelectChessMan(SelectionX, SelectionY);
                selectionChanged = false;
            }
            else
            {
                //move the chessman
                MoveChessMan(SelectionX, SelectionY);
                selectionChanged = false;
            }

        }
    }
    // Method to select a chessman at a given x, y position
    private void SelectChessMan(int x, int y)
    {
        // if it is an empty square
        if (Chessmans[x, y] == null)
        {
            return;
        }
        // if its a piece on the team of who's turn it is 
        if (Chessmans[x, y].isWhite != IsWhiteTurn)
            return;

        // calling possible moves on selected peice 
        allowedMoves = Chessmans[x, y].PossibleMove();
        // sets selected chessman
        selectedChessMan = Chessmans[x, y];
        // gets the highlights for the possible moves 
        BoardHighlights.Instance.HighLightAllowedMoves(allowedMoves);

    }
    // method to move the chess man to a given x, y position 
    private void MoveChessMan(int x, int y)
    {
        // checking if its a valid move 
        if (allowedMoves[x, y] == ChessMan.MoveType.canMove || allowedMoves[x, y] == ChessMan.MoveType.attack)
        {
            ChessMan c = Chessmans[x, y];

            if (c != null && c.isWhite != IsWhiteTurn)
            {
                //if it is the king
                if (c.GetType() == typeof(King))
                {
                    c.SetAttacks(ActiveChessMan);

                    EndGame();
                    return;
                }
                //Capture a piece
                ActiveChessMan.Remove(c);
                Destroy(c.gameObject);

            }

            // handing the Enpassant move for the pawn
            if (x == EnPassant[0] && y == EnPassant[1])
            {
                if (IsWhiteTurn)
                {
                    c = Chessmans[x, y - 1];
                    ActiveChessMan.Remove(c);
                    Destroy(c.gameObject);
                }
                else
                {
                    c = Chessmans[x, y + 1];
                    ActiveChessMan.Remove(c);
                    Destroy(c.gameObject);
                }
            }
            EnPassant[0] = -1;
            EnPassant[1] = -1;

            // if its the pawn and its at the end of the board promoting to queen
            if (selectedChessMan.GetType() == typeof(Pawn))
            {

                //Pawn Promotion--> only Queen.
                if (y == 7)
                {
                    ActiveChessMan.Remove(c);
                    Destroy(c.gameObject);
                    SpawnChessMan(1, x, y, 0.42f);
                }
                else if (y == 0)
                {
                    ActiveChessMan.Remove(c);
                    Destroy(c.gameObject);
                    SpawnChessMan(7, x, y, 0.42f);
                }


                if (selectedChessMan.CurrentY == 1 && y == 3)
                {
                    EnPassant[0] = x;
                    EnPassant[1] = y - 1;
                }

                else if (selectedChessMan.CurrentY == 6 && y == 4)
                {
                    EnPassant[0] = x;
                    EnPassant[1] = y + 1;
                }
            }

            // clearing location in chessmans
            Chessmans[selectedChessMan.CurrentX, selectedChessMan.CurrentY] = null;
            // moving the peice 
            selectedChessMan.transform.position = GetTileCenter(x, y, selectedChessMan.CurrentZ);
            // setting new position in the chessman
            selectedChessMan.SetPosition(x, y);
            //re call possible moves for the new location
            selectedChessMan.PossibleMove();
            Chessmans[x, y] = selectedChessMan;
            // switching the turn
            IsWhiteTurn = !IsWhiteTurn;
            // switching the view 
            camSwitcherObj.SwitchCam(IsWhiteTurn);
        }
        // hiding the highlights
        BoardHighlights.Instance.HidehighLights();
        // deselecting the chessman
        selectedChessMan = null;
    }
    /// <summary>
    /// method to spawn a chessman 
    /// </summary>
    /// <param name="index">index of the piece to spawn</param>
    /// <param name="x">postion in the x of the piece </param>
    /// <param name="y">postion in the y of the piece</param>
    /// <param name="z">postion in the z of the piece (float)</param>
    private void SpawnChessMan(int index, int x, int y, float z)
    {
        // Instantiating the chess man
        ChessMan go = Instantiate(chessmanPrefabs[index], GetTileCenter(x, y, z), orientation);
        // setting the pos and adding to all lists and setting the pos in the piece 
        go.transform.SetParent(transform);
        Chessmans[x, y] = go.GetComponent<ChessMan>();
        Chessmans[x, y].SetPosition(x, y);
        ActiveChessMan.Add(go);

    }

    // method to spawn all the chess man at the begining of the game
    private void SpawnAllChessMan()
    {
        // creating a new list of Active Chess Man, Chessmans and EnPassant
        ActiveChessMan = new List<ChessMan>();
        Chessmans = new ChessMan[8, 8];
        EnPassant = new int[2] { -1, -1 };

        //Spawn White Team
        //King
        SpawnChessMan(0, 4, 0, 0.42f);
        //Queen
        SpawnChessMan(1, 3, 0, 0.42f);
        //Rooks
        SpawnChessMan(3, 0, 0, 0.42f);
        SpawnChessMan(3, 7, 0, 0.42f);
        //Bishops
        SpawnChessMan(2, 2, 0, 0.42f);
        SpawnChessMan(2, 5, 0, 0.42f);
        //Knights
        SpawnChessMan(4, 1, 0, 0.1f);
        SpawnChessMan(4, 6, 0, 0.1f);

        //Pawns
        for (int xTile = 0; xTile < 8; xTile++)
        {
            SpawnChessMan(5, xTile, 1, 0.3f);
        }

        //Spawn Black Team
        //King
        SpawnChessMan(6, 4, 7, 0.42f);
        //Queen
        SpawnChessMan(7, 3, 7, 0.42f);
        //Rooks
        SpawnChessMan(9, 0, 7, 0.42f);
        SpawnChessMan(9, 7, 7, 0.42f);
        //Bishops
        SpawnChessMan(8, 2, 7, 0.42f);
        SpawnChessMan(8, 5, 7, 0.42f);
        //Knights
        SpawnChessMan(10, 1, 7, 0.1f);
        SpawnChessMan(10, 6, 7, 0.1f);

        //Pawns
        for (int xTile = 0; xTile < 8; xTile++)
        {
            SpawnChessMan(11, xTile, 6, 0.3f);
        }
    }

    // helper Method to get the tile center
    private Vector3 GetTileCenter(int x, int y, float z)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (tile_Size * x) + tile_OffSet;
        origin.z += (tile_Size * y) + tile_OffSet;
        origin.y += z;
        return origin;
    }


    // method to call save game passes the BoardManager in
    public void SaveGame()
    {
        if (this != null)
        {
            SaveSystem.SaveBoard(this);
            UpDateGameText.OnSaveGame();
        }


    }

    // Method to load the game back 
    // take a gamedata for a single game 
    public void LoadGame(GameData data)
    {
        //clearing the board
        foreach (ChessMan c in ActiveChessMan)
        {
            Destroy(c.gameObject);
        }
        ActiveChessMan.Clear();
        // getting the data
        bool isItWhiteTurn = data.isWhiteTurn;
        List<PieceData> saved = data.chessManToSave;

        // spawning the chessmen for each saved piece
        foreach (PieceData piece in saved)
        {
            int name = (int)piece.Name;
            int xLoc = piece.CurrentX;
            int yLoc = piece.CurrentY;
            float zLoc = piece.CurrentZ;
            bool white = piece.IsWhite;

            if (white)
            {
                SpawnChessMan(name, xLoc, yLoc, zLoc);
            }
            else
            {
                int darkname = (int)piece.Name + 6;
                SpawnChessMan(darkname, xLoc, yLoc, zLoc);
            }
        }
        camSwitcherObj.SetCameras();
    }

    //method to End the Game Checks who's turn called when a king is killed
    private void EndGame()
    {
        if (IsWhiteTurn)
        {
            UpDateGameText.OnWhiteWins();
            UnityEngine.Debug.Log("White wins the match!");
        }
        else
        {
            UpDateGameText.OnBlackWins();
            UnityEngine.Debug.Log("Black wins the match!");
        }

        foreach (ChessMan c in ActiveChessMan)
        {
            Destroy(c.gameObject);
        }


        // resets the game

        IsWhiteTurn = true;
        camSwitcherObj.SetCameras();

        BoardHighlights.Instance.HidehighLights();
        SpawnAllChessMan();

    }

}
