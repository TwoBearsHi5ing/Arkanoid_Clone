using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button ContinueButton;
    public Button NewGameButton;

    public void ContinueButtonClick()
    {
        DisableButtons();
        
        SceneManager.LoadScene(1);
    }
    public void NewGameButtonClick()
    {
        DisableButtons();
        DataManager.instance.NewGame();
        DataManager.instance.SaveGame();
        SceneManager.LoadScene(1);
    }
    public void DisableButtons()
    { 
        NewGameButton.interactable = false;
        ContinueButton.interactable = false;
    }
    public void EnableButtons()
    {
        NewGameButton.interactable = true;
        ContinueButton.interactable = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void Start()
    {
       
        //EnableButtons();
        if (!DataManager.instance.GameDataExists())
        {
            ContinueButton.interactable = false;
        }
    }
}
