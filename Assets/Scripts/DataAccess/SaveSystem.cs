using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


/// <summary>
/// Class that handles the actual saving duties
/// </summary>
public static class SaveSystem
{
    // List of all saved games of type GameData
    public static List<GameData> savedGames = new List<GameData>();
    
    /// <summary>
    /// Method that saves the game
    /// Serializes all the data
    /// Writes it to a persistent data path
    /// </summary>
    /// <param name="boardManager">takes a boardManager as a Parameter of type BoardManager</param>
    public static void SaveBoard (BoardManager boardManager)
    {
        // Creates a new GameData Object
        GameData data = new GameData(boardManager);
        // Addes the Game to the list of saved games
        savedGames.Add(data);
        // Creates Formatter and Path
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/board.gbm";
        // Stream with mode Create
        FileStream stream = new FileStream(path, FileMode.Create);
        // Serializes the list of savedGames
        formatter.Serialize(stream, savedGames);
        // Closes the stream
        stream.Close();
        Debug.Log("Saved " + savedGames);
    }

    /// <summary>
    /// Method to Load a game
    /// </summary>
    public static void LoadGame()
    {
        // stores the path of the game
        string path = Application.persistentDataPath + "/board.gbm";
        // checking if the path exists 
        if (File.Exists(path))
        {
            // creates a formater and stream with file mode Open
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            // Deserializing casting to a list of GameData and setting the saved games list
            savedGames = (List<GameData>)formatter.Deserialize(stream);
            // closing the stream
            stream.Close();
            Debug.Log("Found " + savedGames);
        }
        //else logging an error
        else
        {
            UpDateGameText.OnLoadFailed();
            Debug.LogError("Save file not found in " + path);
        }
    }
   
}
