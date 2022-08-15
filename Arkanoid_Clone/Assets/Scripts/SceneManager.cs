using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Image fader;

    public static SceneManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            fader.gameObject.SetActive(false);
        }
        else 
        {
            Destroy(gameObject);
        }
       
    }

    public static void LoadScene(int index, float duration = 0.5f, float waitTime = 0.5f)
    {
        instance.StartCoroutine(instance.FadeScene(index, duration, waitTime));
    }

    private IEnumerator FadeScene(int index, float duration, float waitTime)
    { 
        fader.gameObject.SetActive(true);

        for (float i = 0; i < 1; i += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, i));
            yield return null;
        }

        AsyncOperation load = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(index);

        while (!load.isDone)
        { 
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        for (float i = 0; i < 1; i += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, i));
            yield return null;
        }

        fader.gameObject.SetActive(false);
    }

    
}
