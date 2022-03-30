
using UnityEngine;

public class Board : MonoBehaviour
{
    // locations for the cursor functionality
    private int LocationX = -1;
    private int LocationY = -1;

    // gets the prefabs
    public GameObject selectionPreFab;
    private GameObject selectTile;
    // Start is called before the first frame update
    // draws the board and instantiates the prefab
    void Start()
    {
        DrawChessBoard();
        selectTile = Instantiate(selectionPreFab);
    }

    // Update is called once per frame
    void Update()
    {
        // calls update the location
        UpdateLocation();

        ShowCurrentSquare(LocationX, LocationY);

        // gets a mouse down
        if (Input.GetMouseButtonDown(0))
        {
            // calls get selection
            GetSelection();
        }
    }
    // gets current selection and updates the boardmanagers Selection X,Y
    private void GetSelection()
    {

        if (LocationX >= 0 && LocationY >= 0)
        {
            BoardManager.Instance.SelectionX = LocationX;
            BoardManager.Instance.SelectionY = LocationY;
            BoardManager.Instance.selectionChanged = true;
        }

    }
    //Updates the location by reading a Point to ray from a ray cast for eacgh camera
    // sets the locations to this value
    private void UpdateLocation()
    {
        if (Camera.allCameras == null)
            return;

        foreach (Camera camera in Camera.allCameras)
        {
            if (BoardManager.Instance.IsWhiteTurn && camera.name == "PlayerOneCamera")
            {
                RaycastHit hit;
                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
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
            if (!BoardManager.Instance.IsWhiteTurn && camera.name == "PlayerTwoCamera")
            {
                RaycastHit hit;
                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("ChessPlane")))
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
        }



    }
    // draws a debug chess grid
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

    /// <summary>
    /// method to show the current cursor square with a prefab
    /// </summary>
    /// <param name="xPos">x pos of the cursor </param>
    /// <param name="yPos">y pos of the cursor</param>

    private void ShowCurrentSquare(int xPos, int yPos)
    {

        //Show the Selection
        if (xPos >= 0 && yPos >= 0)
        {
            selectTile.SetActive(true);
            selectTile.transform.position = new Vector3(xPos + 0.5f, 0f, yPos + 0.5f);
        }
        else
        {
            // deselect clears the selection when out of range of the board
            selectTile.SetActive(false);
        }
    }

}
