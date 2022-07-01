using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/player.ree";
    public static void SavePlayer(Unit unit)
    {
        path = Application.persistentDataPath +"/"+ GlobalControl.Instance.saveID +"/player.ree";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(unit);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save file in " + path);
    }

    public static PlayerData LoadPlayer(int? i)
    {
        if (i != null) { path = Application.persistentDataPath + "/" + i + "/player.ree"; }
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeletePlayer(int? i)
    {
        if (i != null) { path = Application.persistentDataPath + "/" + i + "/player.ree"; }
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }
}
