using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{
	public GameObject loadpage;
	public GUIStyle myStyle;
    private void Start()
    {
       SaveSystem.LoadGame(); 
    }
    void OnGUI()
	{
		GUILayout.Box("Select Save File");
		GUILayout.Space(10);
		


		foreach (GameData g in SaveSystem.savedGames)
		{
			if (GUILayout.Button("Saved On  " + g.date.ToShortDateString() + " at " + g.date.TimeOfDay, myStyle) )
			{
			
				BoardManager.Instance.LoadGame(g);
				loadpage.SetActive(false);
				
			}

		}
	}
}