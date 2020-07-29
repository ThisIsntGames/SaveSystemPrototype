using UnityEngine;

namespace SaveSystem
{
    public class CurrentFile : MonoBehaviour
    {
        public GameFile CurrentGameFile;
        
        public void SaveCurrentGame()
        {
            CurrentGameFile.SaveGame();
        }
    }
}
