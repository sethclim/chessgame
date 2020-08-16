using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Load Menu Script
/// Runs on the LoadMenu Game Object
/// </summary>
public class LoadMenu : MonoBehaviour
{
	// Holds a reference to the loadpage Game Object
	public GameObject loadpage;
	// Holds a reference to the GUIStyle Object myStyle
	public GUIStyle myStyle;
	
	/// <summary>
	/// On Start Calling LoadGame in the SaveSystem Class
	/// </summary>
    private void Start()
    {
       SaveSystem.LoadGame(); 
    }

	/// <summary>
	/// On GUI drawing menu and list of saved games
	/// </summary>
    void OnGUI()
	{
		// Drawing title
		GUILayout.Box("Select Save File");
		GUILayout.Space(10);
		
		// Looping through all the saved games
		foreach (GameData game in SaveSystem.savedGames)
		{
			// Clicked on loading the game
			// Puts a string in the button showing relevent game info
			if (GUILayout.Button("Saved On  " + game.date.ToShortDateString() + " at " + game.date.TimeOfDay, myStyle) )
			{
				// Telling BoardManager to Load the game with the game data
				BoardManager.Instance.LoadGame(game);
				// closing the load page
				loadpage.SetActive(false);
				
			}

		}
	}
}