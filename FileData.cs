using UnityEngine;

namespace SaveSystem
{
    public class FileData : MonoBehaviour
    {
        public GameData gameData;
    
        public FileData(GameFile gameFile)
        {
            gameData = gameFile.gameData;
        }
    }
}
