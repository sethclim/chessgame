using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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

    private Quaternion orientation = Quaternion.Euler(-90, -90, 0);


    private bool isWhiteTurn = true;

    public bool IsWhiteTurn { get { return isWhiteTurn; } }
    public bool selectionChanged = false;

    public List<ChessMan> chessmanPrefabs;
    private List<ChessMan> activeChessMan;
    public List<ChessMan> ActiveChessMan { get { return activeChessMan; } }
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

        if (Chessmans[x, y].isWhite != isWhiteTurn)
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

            //Capture a peice
            if (c != null && c.isWhite != isWhiteTurn)
            {
                activeChessMan.Remove(c);
                Destroy(c.gameObject);
                //if it is the king
                if (c.GetType() == typeof(King))
                {
                    //End Game
                    return;
                }
            }


            Chessmans[selectedChessMan.CurrentX, selectedChessMan.CurrentY] = null;
            selectedChessMan.transform.position = GetTileCenter(x, y, selectedChessMan.CurrentZ);
            selectedChessMan.SetPosition(x, y);
            Chessmans[x, y] = selectedChessMan;
            isWhiteTurn = !isWhiteTurn;
            camSwitcherObj.SwitchCam(isWhiteTurn);
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
        activeChessMan.Add(go);

    }

    private void SpawnAllChessMan()
    {
        activeChessMan = new List<ChessMan>();
        Chessmans = new ChessMan[8, 8];

        //Spawn White Team
        //King
        SpawnChessMan(0, 4, 0, 0.42f);
        //Queen
        SpawnChessMan(1, 3, 0, 0.42f);
        //Rooks
        SpawnChessMan(3, 0, 0, 0.42f);
        SpawnChessMan(3, 7, 0, 0.32f);
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
        foreach(ChessMan c in activeChessMan)
        {
            Destroy(c.gameObject);
        }
        activeChessMan.Clear();
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

}
