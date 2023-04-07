using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavePosition
{
    
    public static void savePos(AdvisingDialogue p)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savePos.zon";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerPos data = new PlayerPos(p);

        formatter.Serialize(stream, data);
        stream.Close();

    }


    public static PlayerPos loadPos()
    {
        string path = Application.persistentDataPath + "/savePos.zon";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerPos data = formatter.Deserialize(stream) as PlayerPos;
            stream.Close();

            return data;

        }else
        {
            Debug.LogError("Save File not found in" + path);
            return null;
        }
    }

}

