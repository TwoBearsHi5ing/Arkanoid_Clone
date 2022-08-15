using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGrid : MonoBehaviour
{
    public static BoardGrid instance;

    private int height = 10;
    private int width = 10;
    private float spaceSize_x = 1.3f;
    private float spaceSize_y = 0.31f;

    

    int[,] emptyBoard = new int[10, 10]
        {
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0},
                {0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0}
        };

    

    public GameObject emptyPrefab;
    public Transform gridStart;
    public SpriteRenderer backGround;

    public delegate void BlockBreak();
    public static event BlockBreak OnBlockBreak;

    // lista z prefabami dostepnych blokow
    private List<GameObject> blockPrefabs = new List<GameObject>();

    // lista z funkcjami do generowania planszy
    private List<Action> functions = new List<Action>();

    private ColorPalette palette;
    public GameObject[,] gameGrid;

    public GameObject[,] CurrentBackUpGrid;
    public GameObject[] OneDArrayBackup;
    public GameObject[,] OriginalGrid;

    private MapGenerator mapGenerator = new MapGenerator();

    public void ResetBoard()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                instance.emptyBoard[i, j] = 0;
                if (instance.gameGrid[i, j] != null)
                {
                    Destroy(instance.gameGrid[i, j]);
                }
               
            }
        }
    }
    public bool CheckIfGridIsEmpty()
    {
        foreach (GameObject g in gameGrid)
        {
            if (g != null)
            {
                if (!g.GetComponent<Block>().broken)
                {
                    return false;
                }
            }
            
        }
        return true;
    }

    public void CreateGrid(int seed)
    {


        UnityEngine.Random.InitState(seed);
       
        palette = Settings.instance.palettes[UnityEngine.Random.Range(0, Settings.instance.palettes.Length)];

        int randomFuncIndex = UnityEngine.Random.Range(0, functions.Count);
        functions[randomFuncIndex]();
     
       

        int backGroundColorIndex = palette.colors.Length - 1;
        int k = 0;

      



        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (emptyBoard[i, j] == 1)
                {

                    backGround.color = palette.colors[backGroundColorIndex];
                    if (k == palette.colors.Length - 1)
                    {
                        k = 0;
                    }
                    GameObject block = blockPrefabs[mapGenerator.RandomizedBlocks()];
                    block.GetComponent<SpriteRenderer>().color = palette.colors[k];

                    k++;
                    gameGrid[i, j] = Instantiate(block, new Vector3(gridStart.position.x + (spaceSize_x * i), gridStart.position.y + (spaceSize_y * j)), Quaternion.identity);
                    gameGrid[i, j].transform.parent = transform;
                    gameGrid[i, j].gameObject.name = $"Block {i}: {j}";

                }


            }
        }
       
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
    }
    private void Start()
    {
        IDFactory.ResetIDs();
        gameGrid = new GameObject[width, height];
        PopulateBlockList();
        PopulateFuncList();
      
     
        DataManager.instance.LoadGame();

        CreateGrid(Seed.instance.SeedList[GameManager.instance.CurrentLevelIndex]);

        StartCoroutine(Wait());

    }

    private void PopulateBlockList()
    {
        blockPrefabs.Add(Settings.instance.block01Prefab);
        blockPrefabs.Add(Settings.instance.block02Prefab);
        blockPrefabs.Add(Settings.instance.block03Prefab);
        blockPrefabs.Add(Settings.instance.block04Prefab);
       
       

    }
    private void PopulateFuncList()
    {
        int randomMapOrientation = UnityEngine.Random.Range(0, 4);
       
        functions.Add(()=> mapGenerator.CheckerBoard(emptyBoard));

        functions.Add(() => mapGenerator.Stack(emptyBoard, randomMapOrientation));

        functions.Add(() => mapGenerator.MultipleRectangles(emptyBoard));
    }

    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(0.01f);
        DataManager.instance.LoadGame();
        DataManager.instance.SaveGame();
    }

    
}
