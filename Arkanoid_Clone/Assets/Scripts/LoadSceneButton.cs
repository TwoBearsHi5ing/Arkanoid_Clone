using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadSceneFormButton(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }
    
}
