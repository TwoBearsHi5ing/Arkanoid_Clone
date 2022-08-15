using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Seed : MonoBehaviour , IDataPersistence
{
    public static Seed instance;

    public int LevelStringSeed;
    public int CurrentSeed = 0;

    
    public bool useStringSeed;
    public bool useRandomSeed;

    public List<int> SeedList = new List<int>();

    public void LoadData(GameData data)
    {
        SeedList = data.CurrentSeedList.ToList();
    }

    public void SaveData(GameData data)
    {
        data.CurrentSeedList = SeedList.ToList();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (useStringSeed)
        {
            CurrentSeed = LevelStringSeed.GetHashCode();
        }

        if (useRandomSeed)
        {
            CurrentSeed = (int)System.DateTime.Now.Ticks;
        }
        
     //   UnityEngine.Random.InitState(CurrentSeed);
    }
}
