using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This holds the game save for the game currently loaded.
//You must find THIS object to do THESE functions.
//This is dirty code, and should be all done with events.
//But it works, and is what I used on Don't Eat Poison!

namespace SaveSystem
{
    public class GameFile : MonoBehaviour
    {
        //The class GameData contains all the variables I need to save.
        public GameData gameData;

        public void Start()
        {
            LoadGame();
        }

        public void SaveGame()
        {
            SaveSystemFunction.SaveGameFile(this);
        }
        
        public void DeleteGame()
        {
            SaveSystemFunction.DeleteGameFile(this);
        }
        
        public void LoadVariables(FileData fileData)
        {
            gameData = fileData.gameData;
        }
        
        public void LoadGame()
        {
            FileData data = SaveSystemFunction.LoadGameFile(this);
            if (data == null) return;
            print("Gamefile Loaded To Menu:" + gameData.fileNumber);
            LoadVariables(data);
        }
    }
}