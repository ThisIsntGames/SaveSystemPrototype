using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//This saves and loads games.
//Currently this is a monobehavior and is set to an instantiated object.
//I think I can get away from it being a monobehavior.

namespace SaveSystem
{
    public class SaveSystemFunction : MonoBehaviour
    {
        //This creates a gamesave in the default save area.
        //It will work on every platform I've tested.
        public static void SaveGameFile(GameFile gameFile)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            var path = FilePath(gameFile);
            FileStream stream = new FileStream(path, FileMode.Create);

            FileData data = new FileData(gameFile);

            formatter.Serialize(stream, data);
            stream.Close();

            Debug.Log("Save File Created in " + path);
        }

        //This loads your game file.
        public static FileData LoadGameFile(GameFile gameFile)
        {
            var path = FilePath(gameFile);
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                FileData data = formatter.Deserialize(stream) as FileData;
                stream.Close();
                Debug.Log("Save File Loaded from " + path);
                return data;
            }
            else
            {
                Debug.LogWarning("Save file not found in " + path);
                return null;
            }
        }
        
        //This will delete a gamefile.
        public static void DeleteGameFile(GameFile gameFile)
        {
            var path = FilePath(gameFile);
            if (File.Exists(path))
            {
                Debug.Log("Save File Deleted from " + path);
                File.Delete(path);
            }
            else
            {
                Debug.LogError("Delete Error: Save file not found in " + path);
            }
        }

        //This creates the name of the gamefile. 
        //IT CAN BE NAMED ANYTHING AFTER THE FORWARD SLASH.
        public static string FilePath(GameFile gameFile)
        {
            return Application.persistentDataPath + "/" + gameFile.gameData.fileNumber + ".save";
        }
    }
}
