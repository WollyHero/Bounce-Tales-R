using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
[System.Serializable]
public class SaveClass {
    // Reminder: this area is ok
    public int checkpoint;
    public int eggCount;
    public float timeElapsed;
    public SaveClass(int Acheckpoint, int AeggCount, float AtimeElapsed, List<int> Detach) {
        checkpoint = Acheckpoint;
        eggCount = AeggCount;
        timeElapsed = AtimeElapsed;
    }
    public List<int> Unload_obj = new List<int>();
    private string BaseDirectory = "/saves/";

    // make base directory (NEEDED)
    public void CreateBaseDirectory() {
        if (!Directory.Exists(Application.persistentDataPath + BaseDirectory)) {
            Directory.CreateDirectory(Application.persistentDataPath + BaseDirectory);
        }
    }
    // just in case we need to delete the save
    public void DeleteSave() {
        if (Directory.Exists(Application.persistentDataPath + BaseDirectory)) {
            Directory.Delete(Application.persistentDataPath + BaseDirectory);
        }
    }
    public SaveClass ParseToClass(string fileName) {
        string path = Application.persistentDataPath + BaseDirectory + fileName + ".rsav";
        // for prevention
        if (!Directory.Exists(Application.persistentDataPath + BaseDirectory)) {
            Debug.LogError("Directory: " + Application.persistentDataPath + BaseDirectory +
                           " DONT EXISTS. Create one by calling `CreateBaseDirectory`");
            Debug.LogWarning("Returning a empty class as result");
            return new SaveClass(0, 0, 0, new List<int>());
        }
        if (File.Exists(path)) {
            BinaryFormatter binFormater = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveClass parsed = binFormater.Deserialize(stream) as SaveClass;
            stream.Close();
            return parsed;
        } else {
            Debug.LogError("The file: " + path +
                           "doesn't exist. Try creating a instance first. RETURNING A EMPTY CLASS");
            return new SaveClass(0, 0, 0, new List<int>());
        }
    }
    public void WriteClass(SaveClass saveContent, string FileName) {
        BinaryFormatter binFormater = new BinaryFormatter();
        string path = Application.persistentDataPath + BaseDirectory + FileName + ".rsav";  // true
        // prevention
        if (!Directory.Exists(Application.persistentDataPath + BaseDirectory)) {
            Debug.LogError("Directory: " + Application.persistentDataPath + BaseDirectory +
                           " DONT EXISTS. Create one by calling `CreateBaseDirectory`");
            return;
        }
        // create or open the file based if it Exists
        if (File.Exists(path)) {
            FileStream stream = new FileStream(path, FileMode.Open);
            binFormater.Serialize(stream, saveContent);
            stream.Close();
        } else {
            FileStream stream = new FileStream(path, FileMode.Create);
            binFormater.Serialize(stream, saveContent);
            stream.Close();
        }
    }
}
