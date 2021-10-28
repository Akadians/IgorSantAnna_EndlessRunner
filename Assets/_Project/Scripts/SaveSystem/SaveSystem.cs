using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static readonly string savePath = Application.persistentDataPath + "/Saves/";

    public static void Init()
    {        
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);            
        }
    }

    public static void SaveBoard(string saveString)
    {
        File.WriteAllText(savePath + "save.json", saveString);        
    }

    public static string LoadBoard()
    {        
        if (File.Exists(savePath + "save.json"))
        {            
            string dataLoaded = File.ReadAllText(savePath + "save.json");
            return dataLoaded;
        }
        else
        {            
            return null;
        }
    }
}
