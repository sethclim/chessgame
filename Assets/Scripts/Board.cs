using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private int LocationX = -1;
    private int LocationY = -1;

    public GameObject selectionPreFab;
    private GameObject selectTile;
    // Start is called before the first frame update
    void Start()
    {
        DrawChessBoard();
        selectTile = Instantiate(selectionPreFab);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLocation();

        ShowCurrentSquare(LocationX, LocationY);

        if (Input.GetMouseButtonDown(0))
        {
            GetSelection();
        }
    }

    private void GetSelection()
    {

        if (LocationX >= 0 && LocationY >= 0)
        {
            BoardManager.Instance.SelectionX = LocationX;
            BoardManager.Instance.SelectionY = LocationY;
            BoardManager.Instance.selectionChanged = true;
        }

    }
    private void UpdateLocation()
    {
        if (!Camera.main)
            return;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
        {
            LocationX = (int)hit.point.x;
            LocationY = (int)hit.point.z;

        }
        else
        {
            LocationX = -1;
            LocationY = -1;
        }
    }

    private void DrawChessBoard()
    {
        Vector3 widthline = Vector3.right * 8;
        Vector3 heightline = Vector3.forward * 8;

        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthline);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightline);

            }
        }
    }

    private void ShowCurrentSquare(int xPos, int yPos)
    {

        //Show the Selection
        if (xPos >= 0 && yPos >= 0)
        {
            selectTile.SetActive(true);
            selectTile.transform.position = new Vector3(xPos + 0.5f, 0f, yPos + 0.5f);

            Debug.Log(BoardManager.Instance.SelectionX);
            Debug.Log(BoardManager.Instance.SelectionY);
        }
        else
        {
            selectTile.SetActive(false);
        }
    }

}
