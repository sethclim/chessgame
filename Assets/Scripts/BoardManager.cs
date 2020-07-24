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

    public List<GameObject> chessmanPrefabs;
    private List<GameObject> activeChessMan = new List<GameObject>();


    private void Start()
    {
        SpawnChessMan(0, Vector3.zero);
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

        GameObject go = Instantiate(chessmanPrefabs [index], position, Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        activeChessMan.Add(go);

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
