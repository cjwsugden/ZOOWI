using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SavingData
{
    
    public static void saveGame(MainManager mm)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/zoowisave.zon";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveProfile data = new SaveProfile(mm);

        formatter.Serialize(stream, data);
        stream.Close();

    }


    public static SaveProfile loadGame()
    {
        string path = Application.persistentDataPath + "/zoowisave.zon";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveProfile data = formatter.Deserialize(stream) as SaveProfile;
            stream.Close();

            return data;

        }else
        {
            Debug.LogError("Save File not found in" + path);
            return null;
        }
    }

///////////////////////////////////////////////////////////////////////////////////////////////////////////

}
