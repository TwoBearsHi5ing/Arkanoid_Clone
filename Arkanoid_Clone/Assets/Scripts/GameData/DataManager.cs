using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;


    [Header("File Storage Config")]
    [SerializeField]
    private string fileName;

    private GameData gameData;

    private List<IDataPersistence> dataPersistencesObjects;
    private FileDataHandler fileDataHandler;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }
    
  
    

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        this.gameData = fileDataHandler.Load();

    
        if (gameData == null)
        {
            Debug.Log("no Data found while trying to load");
            NewGame();
        }
       
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

    }

    public void SaveGame()
    {    
        if (gameData == null)
        {
            Debug.Log("no Data found while trying to save");
            return;
        }
        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        fileDataHandler.Save(gameData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void DeleteSaveFile()
    {
        fileDataHandler.Delete();
    }

    public bool GameDataExists()
    {
       return fileDataHandler.CheckIfFileExists();
    }


   
}
