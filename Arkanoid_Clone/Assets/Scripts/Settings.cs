using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings instance;

   

    [Header("----------------------------Variables----------------------------------")]
    [Space(10)]
    public int ExtraLifePowerupLimit = 0;
    public int EnlargePowerUpLimit = 0;
    public float EnlargeTime = 3f;
    public float normalScale = 2;
    public float enlargedScale = 3.5f;
    [Range(1,3)]
    public int Difficulty = 1;
    public int LifeAmount = 10;


   



    [Header("----------------------------Sounds------------------------------------")]
    [Space(10)]
    public AudioClip block_01_break;
    public AudioClip ballBounce;
    public AudioClip deathSound;

    [Header("----------------------------Prefabs-----------------------------------")]
    [Space (10)]
    public GameObject ballPrefab;
    public GameObject block01Prefab;
    public GameObject block02Prefab;
    public GameObject block03Prefab;
    public GameObject block04Prefab;
    public GameObject blockImmortalPrefab;
    public GameObject extraHealthPowerUpPrefab;
    public GameObject enlargePowerUpPrefab;
    [Header("----------------------------Color Palettes-----------------------------")]
    public ColorPalette[] palettes;

    public PlayerControlls playerControlls;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
        playerControlls = new PlayerControlls();
    }
    private void OnEnable()
    {
        playerControlls.Enable();
    }
    private void OnDisable()
    {
        playerControlls.Disable();
    }

  
}
