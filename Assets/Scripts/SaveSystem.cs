
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class SaveSystem
{

    public static void SaveBoard (BoardManager boardManager)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/board.gbm";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(boardManager);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Saved " + data);


    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/board.gbm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            Debug.Log("Found " + data.allPieceData.Length);
            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
   
}
