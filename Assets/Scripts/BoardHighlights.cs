using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHighlights : MonoBehaviour
{
    // instance of the highlight class
    public static BoardHighlights Instance { set; get; }
    // public prefab references
    public GameObject highlightPrefab;
    public GameObject attackhighlightPrefab;
    // list of highlights and attack highlights
    private List<GameObject> highlights;
    private List<GameObject> attackHighlights;


    // creates new lists on start
    private void Start()
    {
        Instance = this;
        highlights = new List<GameObject>();
        attackHighlights = new List<GameObject>();
    }

    //gets highlights/ creates or gets active
    private GameObject GetHighlightObject()
    {

        GameObject go = highlights.Find(g => !g.activeSelf);

        if (go == null)
        {
            go = Instantiate(highlightPrefab);
            highlights.Add(go);
        }
        return go;
    }
    //gets attack highlights/ creates or gets active
    private GameObject GetAttackHighlightObject()
    {

        GameObject go = attackHighlights.Find(g => !g.activeSelf);

        if (go == null)
        {
            go = Instantiate(attackhighlightPrefab);
            attackHighlights.Add(go);
        }
        return go;
    }

    //Gets Highlights for the possible moves in the list
    public void HighLightAllowedMoves(ChessMan.MoveType[,] moves)
    {
        // iterates through the moves. if can move gets highlight 
        // if can attack sets attack highlight
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (moves[i, j] == ChessMan.MoveType.canMove)
                {
                    GameObject go = GetHighlightObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i + 0.5f, 0f, j + 0.5f);
                }


                if (moves[i, j] == ChessMan.MoveType.attack)
                {
                    GameObject go = GetAttackHighlightObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i + 0.5f, 0f, j + 0.5f);
                }
            }
        }
    }

    // method to hide the highlights in both lists
    public void HidehighLights()
    {
        foreach (GameObject go in highlights)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in attackHighlights)
        {
            go.SetActive(false);
        }
    }
}
