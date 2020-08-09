using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{
	public GameObject loadpage;

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
			if (GUILayout.Button("Saved On" + g.date + " - " + " - " + "Yass"))
			{
			
				BoardManager.Instance.LoadGame(g);
				loadpage.SetActive(false);
				
			}

		}
	}
}