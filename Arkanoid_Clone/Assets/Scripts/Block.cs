using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum BlockType
{ 
    oneHitBlock,
    twoHitBlock,
    threeHitBlock,
    fourHitBlock,
    immortalBlock  // narazie nie uzywane

}
public enum PowerUps
{ 
    none = 0,
    enlarge = 1,
    extraLife = 2,
}
public class Block : MonoBehaviour, IDataPersistence
{
    public BlockType type;

    public  PowerUps powerUp;
    private int Score;
    private int _health;

    public string ID;
    public bool broken;

   

    public int Health
    { 
        get 
        { 
            return _health; 
        }
        set 
        {
            if (value <= 0)
            {
                OnBreak();
            }
            else
            { 
                _health = value;
            }
        }
    }

    private void Start()
    {
        AssignValues();
        ID = IDFactory.GetUniqueID().ToString();
        broken = false;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (type != BlockType.immortalBlock)
        {
            Health--;
        }
    }
    private void OnDestroy()
    {
        //BoardGrid.instance.EventInvoke();
    }
    private void OnBreak()
    {
        SoundManager.PlaySound(Settings.instance.block_01_break, "BlockBreak");
        GameManager.instance.Score += Score;
        

        if (powerUp != PowerUps.none)
        {
            if (powerUp == PowerUps.extraLife)
            {
                Instantiate(Settings.instance.extraHealthPowerUpPrefab, transform.position, Quaternion.identity);
            }
            else if (powerUp == PowerUps.enlarge)
            {
                Instantiate(Settings.instance.enlargePowerUpPrefab, transform.position, Quaternion.identity);
            }
        }

        broken = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GameManager.instance.NextLevel();
        //Destroy(gameObject);
      
    }
    private void RandomPowerUp(int firstPercentThreshold, int secondPercentThreshold)
    {
        int percent = UnityEngine.Random.Range(0, 100);

        if (percent < firstPercentThreshold)
        {
            powerUp = PowerUps.none;
        }
        else if (percent >= firstPercentThreshold && percent < secondPercentThreshold && GameManager.instance.EnlargePowerUpAmount < Settings.instance.EnlargePowerUpLimit)
        {
            powerUp = PowerUps.enlarge;
            GameManager.instance.EnlargePowerUpAmount++;
        }
        else if (percent >= secondPercentThreshold && GameManager.instance.ExtraLifePowerupAmount < Settings.instance.ExtraLifePowerupLimit)
        {
            powerUp = PowerUps.extraLife;
            GameManager.instance.ExtraLifePowerupAmount++;
        }
    }
    private void AssignValues()
    {
        
        if (type == BlockType.oneHitBlock)
        {
            Health = 1;
            Score = 10;
            RandomPowerUp(90, 98); 
        }

        else if (type == BlockType.twoHitBlock)
        {
            Health = 2;
            Score = 20;
            RandomPowerUp(80, 90);      
        }

        else if (type == BlockType.threeHitBlock)
        {
            Health = 3;
            Score = 30;
            RandomPowerUp(70, 90);
        }

        else if (type == BlockType.fourHitBlock)
        {
            Health = 4;
            Score = 40;
            RandomPowerUp(50, 75);
        }

        else if (type == BlockType.immortalBlock)
        {
            Health = 99;
            Score = 0;
        }
            
    }

    public void LoadData(GameData data)
    {
        
        data.blocksBroken.TryGetValue(ID, out broken);
        if (broken)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void SaveData( GameData data)
    {
        if (data.blocksBroken.ContainsKey(ID))
        { 
            data.blocksBroken.Remove(ID);
        }
        data.blocksBroken.Add(ID, broken);
    }
}
