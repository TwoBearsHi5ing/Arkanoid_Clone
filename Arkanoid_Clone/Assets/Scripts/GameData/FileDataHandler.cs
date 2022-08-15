using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    

    private string dataDirPath = "";

    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    { 
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);


            }
            catch (Exception ex)
            {
                Debug.LogError($"Faild to load data from: {fullPath},\n {ex}");
            }
        }
        return loadedData;

    }
    public void Save(GameData data)
    { 
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                { 
                    writer.Write(dataToStore);
                }
            }
        }
        catch(Exception ex)
        { 
            Debug.LogError($"Faild to save data at: {fullPath},\n {ex}");
        }
        
    }

    public void Delete()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else
            {
                Debug.LogWarning($"Tried to delete save file at: {fullPath} , but nothing was found");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to delete save file at {fullPath}");
        }
    }

    public bool CheckIfFileExists()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

       
            if (File.Exists(fullPath))
            {
              return true;
            }
            else
            {
                return false;
            }
      
    }

}
