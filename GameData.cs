using System;
using System.IO;
using UnityEngine;

namespace SaveSystem
{
    //This holds all the variables for a game save. 
    [System.Serializable]
    public class GameData
    {
        public FileNumber fileNumber;
        public int MaxHealth;
        [Range(0, 10)] public int currentHealth;
        public int coins = 0;
        public TimeHolder timeHolder;
        public Armor[] armors = new Armor[10];
    }

    //Here's an ENUM that names the files with a dropdown menu.
    public enum FileNumber
    {
        File01 = 1, 
        File02 = 2, 
        File03 = 3
    }
    
    //You can make a class hold any other variables you want. 
    //Comes in handy for different things. Here's some examples.
    [System.Serializable]
    public class TimeHolder
    {
        public int minutes;
        public int seconds;
        public int milliseconds;
    }
    
    [System.Serializable]
    public class Armor
    {
        public string name;
        public bool isBreakable;
        public int defenseStat;
    }
}