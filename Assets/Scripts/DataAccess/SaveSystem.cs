
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class SaveSystem
{

    public static List<GameData> savedGames = new List<GameData>();
    public static void SaveBoard (BoardManager boardManager)
    {
        GameData data = new GameData(boardManager);
        savedGames.Add(data);
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/board.gbm";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, savedGames);
        stream.Close();
        Debug.Log("Saved " + savedGames);
    }

    public static void LoadGame()
    {
        string path = Application.persistentDataPath + "/board.gbm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            savedGames = (List<GameData>)formatter.Deserialize(stream);
            stream.Close();
            Debug.Log("Found " + savedGames);
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }
   
}
