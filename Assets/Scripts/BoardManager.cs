using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;  

public class BoardManager : MonoBehaviour
{


    private const float tile_Size = 1.0f;
    private const float tile_OffSet = 0.5f;
    private int selectionX = -1;
    private int selectionY = -1;

    private Quaternion orientation = Quaternion.Euler(-90, -90, 0);

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
    private void SpawnChessMan(int index, Vector3 position)
    {

        GameObject go = Instantiate(chessmanPrefabs [index], position, orientation) as GameObject;
        go.transform.SetParent(transform);
        activeChessMan.Add(go);

    }

    private void SpawnAllChessMan()
    {
        activeChessMan = new List<GameObject>();

        //Spawn White Team
        //King
        SpawnChessMan(0, GetTileCenter(3, 0));
        //Queen
        SpawnChessMan(1, GetTileCenter(4, 0));
        //Rooks
        SpawnChessMan(2, GetTileCenter(0, 0));
        SpawnChessMan(2, GetTileCenter(7, 0));
        //Bishops
        SpawnChessMan(3, GetTileCenter(2, 0));
        SpawnChessMan(3, GetTileCenter(5, 0));
        //Knights
        SpawnChessMan(4, GetTileCenter(1, 0));
        SpawnChessMan(4, GetTileCenter(6, 0));

        //Pawns
        for(int xTile = 0; xTile < 8; xTile++)
        {
            SpawnChessMan(5, GetTileCenter(xTile, 1));
        }

        //Spawn White Team
        //King
        SpawnChessMan(6, GetTileCenter(3, 7));
        //Queen
        SpawnChessMan(7, GetTileCenter(4, 7));
        //Rooks
        SpawnChessMan(8, GetTileCenter(0, 7));
        SpawnChessMan(8, GetTileCenter(7, 7));
        //Bishops
        SpawnChessMan(9, GetTileCenter(2, 7));
        SpawnChessMan(9, GetTileCenter(5, 7));
        //Knights
        SpawnChessMan(10, GetTileCenter(1, 7));
        SpawnChessMan(10, GetTileCenter(6, 7));

        //Pawns
        for (int xTile = 0; xTile < 8; xTile++)
        {
            SpawnChessMan(11, GetTileCenter(xTile, 6));
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
        if(selectionX >=0 && selectionY >= 0)
        {
            Debug.Log(selectionX);
            Debug.Log(selectionY);
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX, 
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            Debug.DrawLine(
                Vector3.forward * (selectionY +1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));

        }



    }
}
