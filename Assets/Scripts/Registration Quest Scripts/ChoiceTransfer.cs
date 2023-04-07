using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class ChoiceTransfer
{
    
    public static void saveChoice(AdvisingDialogue p)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/choice.zon";
        FileStream stream = new FileStream(path, FileMode.Create);

        FacultyChoice data = new FacultyChoice(p);

        formatter.Serialize(stream, data);
        stream.Close();

    }


    public static FacultyChoice loadChoice()
    {
        string path = Application.persistentDataPath + "/choice.zon";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            FacultyChoice data = formatter.Deserialize(stream) as FacultyChoice;
            stream.Close();

            return data;

        }else
        {
            Debug.LogError("Save File not found in" + path);
            return null;
        }
    }

}
