using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    public static void SaveGame (GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveGame.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameData);

        formatter.Serialize(stream, data);
        stream.Close(); 
    }

    public static GameData LoadGame ()
    {
        string path = Application.persistentDataPath + "/saveGame.fun";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData gameData = binaryFormatter.Deserialize(stream) as GameData; 
            stream.Close();

            Debug.Log(path);
            return gameData;
        } 
    
        Debug.LogError("Save file not found in " + path);
        return null;
    }
}
