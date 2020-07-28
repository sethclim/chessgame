using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public ChessMan[,] Chessmans { set; get; }
    private ChessMan selectedChessMan;

    private const float tile_Size = 1.0f;
    private const float tile_OffSet = 0.5f;
    private int selectionX = -1;
    private int selectionY = -1;

    private Quaternion orientation = Quaternion.Euler(-90, -90, 0);

    public bool isWhiteTurn = true;

    public List<GameObject> chessmanPrefabs;
    private List<GameObject> activeChessMan;

    private void Start()
    {
        SpawnAllChessMan();
    }
    private void Update()
    {
        UpdateSelection();
        DrawChessBoard();

 

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse Clicked");
            if (selectionX >= 0 && selectionY >= 0)
            {
                if (selectedChessMan == null)
                {
                    //select the chessman
                    SelectChessMan(selectionX, selectionY);
                    Debug.Log("SelectedChessMan == Null");
                }
                else
                {
                    //move the chess man
                    MoveChessMan(selectionX, selectionY);
                }
            }
        }

    }
    private void SelectChessMan(int x, int y)
    {
        if (Chessmans[x, y] == null)
        {
            Debug.Log("Chessmans[x, y] == null in SelectChess", Chessmans[x, y]);
            return;
        }

        if (Chessmans[x, y].isWhite != isWhiteTurn)
            return;
        selectedChessMan = Chessmans[x, y];
        Debug.Log("SelectChessMan Called", selectedChessMan);
    }
    private void MoveChessMan(int x, int y)
    {
        if (selectedChessMan.PossibleMove(x, y))
        {
            Chessmans[selectedChessMan.CurrentX, selectedChessMan.CurrentY] = null;
            selectedChessMan.transform.position = GetTileCenter(x, y);
            Chessmans[x, y] = selectedChessMan;
        }

        selectedChessMan = null;
    }

    private void UpdateSelection()
    {
        if (!Camera.main)
            return;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;

        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }
    private void SpawnChessMan(int index, int x, int y)
    {

        GameObject go = Instantiate(chessmanPrefabs[index], GetTileCenter(x, y), orientation) as GameObject;
        go.transform.SetParent(transform);
        Chessmans[x, y] = go.GetComponent<ChessMan>();
        Chessmans[x, y].SetPosition(x, y);
        activeChessMan.Add(go);

    }

    private void SpawnAllChessMan()
    {
        activeChessMan = new List<GameObject>();
        Chessmans = new ChessMan[8, 8];

        //Spawn White Team
        //King
        SpawnChessMan(0, 3, 0);
        //Queen
        SpawnChessMan(1, 4, 0);
        //Rooks
        SpawnChessMan(2, 0, 0);
        SpawnChessMan(2, 7, 0);
        //Bishops
        SpawnChessMan(3, 2, 0);
        SpawnChessMan(3, 5, 0);
        //Knights
        SpawnChessMan(4, 1, 0);
        SpawnChessMan(4, 6, 0);

        //Pawns
        for (int xTile = 0; xTile < 8; xTile++)
        {
            SpawnChessMan(5, xTile, 1);
        }

        //Spawn White Team
        //King
        SpawnChessMan(6, 3, 7);
        //Queen
        SpawnChessMan(7, 4, 7);
        //Rooks
        SpawnChessMan(8, 0, 7);
        SpawnChessMan(8, 7, 7);
        //Bishops
        SpawnChessMan(9, 2, 7);
        SpawnChessMan(9, 5, 7);
        //Knights
        SpawnChessMan(10, 1, 7);
        SpawnChessMan(10, 6, 7);

        //Pawns
        for (int xTile = 0; xTile < 8; xTile++)
        {
            SpawnChessMan(11, xTile, 6);
        }
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (tile_Size * x) + tile_OffSet;
        origin.z += (tile_Size * y) + tile_OffSet;
        return origin;
    }
    private void DrawChessBoard()
    {
        Vector3 widthline = Vector3.right * 8;
        Vector3 hieghtline = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthline);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + hieghtline);

            }

        }

        //Draw the Selection
        if (selectionX >= 0 && selectionY >= 0)
        {
            Debug.Log(selectionX);
            Debug.Log(selectionY);
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            Debug.DrawLine(
                Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));

        }



    }
}
