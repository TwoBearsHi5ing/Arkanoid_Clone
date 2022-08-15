using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
  

    public int CurrentScore;
   // public int HighScore;

    public int PlayerLifes;
    public float currentEnlargeTimeData;

    public Vector3 playerPosition;
    public Vector3 playerScale;

    public int LevelIndex;
    public List<int> CurrentSeedList;


    public SerializableDictionary<string, bool> blocksBroken;

    public GameData()
    { 
        this.CurrentScore = 0;
        //this.HighScore = 0;
        this.PlayerLifes = 10;
        this.LevelIndex = 0;


        this.currentEnlargeTimeData = -1;
        this.playerPosition = new Vector3(0, -4.54f, 0);
        this.playerScale = new Vector3(2, 1.5f, 1);

        this.CurrentSeedList = new List<int>
        {
            -622341647,
            1067744992,
            1346490696,
            -1957949060,
            1807190429,
            -502737543,
            123516123,
            -1858894252
        };

        this.blocksBroken = new SerializableDictionary<string, bool>();
       



    }

}
