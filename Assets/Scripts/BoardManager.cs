using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; set; }

    private ChessMan.MoveType[,] allowedMoves { set; get; }
    public ChessMan[,] Chessmans { set; get; }
    private ChessMan selectedChessMan;

    public CamSwitcher camSwitcherObj;
    private const float tile_Size = 1.0f;
    private const float tile_OffSet = 0.5f;

    public int SelectionX { get; set; } = -1;
    public int SelectionY { get; set; } = -1;

    private readonly Quaternion orientation = Quaternion.Euler(-90, -90, 0);

    public int[] EnPassant { get; set; }

    public bool IsWhiteTurn { get; private set; } = true;
    public bool selectionChanged = false;

    public List<ChessMan> chessmanPrefabs;
    public List<ChessMan> ActiveChessMan { get; private set; }
    public Board currentBoard;

    public Notifications notifications;


    private void Start()
    {
        Instance = this;
        notifications = Instantiate(notifications) as Notifications;
        camSwitcherObj = Instantiate(camSwitcherObj) as CamSwitcher;
        camSwitcherObj.SetCameras();
        SpawnAllChessMan();
    }
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
    private void SelectChessMan(int x, int y)
    {
        if (Chessmans[x, y] == null)
        {
            return;
        }

        if (Chessmans[x, y].isWhite != IsWhiteTurn)
            return;

        allowedMoves = Chessmans[x, y].PossibleMove();
        selectedChessMan = Chessmans[x, y];
        BoardHighlights.Instance.HighLightAllowedMoves(allowedMoves);

    }
    private void MoveChessMan(int x, int y)
    {
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
            if (selectedChessMan.GetType() == typeof(Pawn))
            {
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


            Chessmans[selectedChessMan.CurrentX, selectedChessMan.CurrentY] = null;
            selectedChessMan.transform.position = GetTileCenter(x, y, selectedChessMan.CurrentZ);
            selectedChessMan.SetPosition(x, y);
            //re call possible moves for the new location
            selectedChessMan.PossibleMove();
            Chessmans[x, y] = selectedChessMan;
            IsWhiteTurn = !IsWhiteTurn;
            camSwitcherObj.SwitchCam(IsWhiteTurn);
        }

        BoardHighlights.Instance.HidehighLights();
        selectedChessMan = null;
    }
    private void SpawnChessMan(int index, int x, int y, float z)
    {

        ChessMan go = Instantiate(chessmanPrefabs[index], GetTileCenter(x, y, z), orientation) as ChessMan;
        go.transform.SetParent(transform);
        Chessmans[x, y] = go.GetComponent<ChessMan>();
        Chessmans[x, y].SetPosition(x, y);
        ActiveChessMan.Add(go);

    }

    private void SpawnAllChessMan()
    {
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

    private Vector3 GetTileCenter(int x, int y, float z)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (tile_Size * x) + tile_OffSet;
        origin.z += (tile_Size * y) + tile_OffSet;
        origin.y += z;
        return origin;
    }


    public void SaveGame()
    {
        if (this != null)
        {
            SaveSystem.SaveBoard(this);
            notifications.pushSavedGame();
        }


    }

    public void LoadGame(GameData data)
    {
        foreach (ChessMan c in ActiveChessMan)
        {
            Destroy(c.gameObject);
        }
        ActiveChessMan.Clear();
        bool isItWhiteTurn = data.isWhiteTurn;
        List<PieceData> saved = data.chessManToSave;

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
        camSwitcherObj.SwitchCam(!isItWhiteTurn);
    }

    private void EndGame()
    {
        if (IsWhiteTurn)
        {
            UnityEngine.Debug.Log("White wins the match!");
        }
        else
        {
            UnityEngine.Debug.Log("Black wins the match!");
        }

        foreach (ChessMan c in ActiveChessMan)
        {
            Destroy(c.gameObject);
        }

        IsWhiteTurn = true;
        BoardHighlights.Instance.HidehighLights();
        SpawnAllChessMan();

    }

}
