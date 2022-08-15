using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public static GameManager instance;

    public Transform startingBallPosition;
    

    public GameObject PauseMenu;
    public GameObject YouWonPanel;

    public GameObject GameOverText;

    public GameObject SaveNotification;

    public GameObject EndGameLabel;
    public GameObject EndGameWall;

    public TMP_Text ScoreText;
    public TMP_Text MenuScoreText;
    public TMP_Text HighScoreText;
    public TMP_Text MenuHighScoreText;

    public TMP_Text LevelIndexText;


    public TMP_Text LifesText;

    public TMP_Text TimerText;
    public GameObject TimerObject;

    public Button ResumeButton;
    public Button SaveButton;

    public bool gameOver;
    public bool gameEnded;

    public int ExtraLifePowerupAmount;
    public int EnlargePowerUpAmount;

    private int _currentLevelindex;
    public int CurrentLevelIndex
    {
        get
        { 
            return _currentLevelindex;
        }
        set
        {
            _currentLevelindex = value;
            LevelIndexText.text = (CurrentLevelIndex + 1).ToString();
        }
    }



    private float TimeToDisplay;

    private int _score;
    public int Score
    { 
        get 
        { 
            return _score; 
        }
        set 
        {
            _score = value;
            ScoreText.text = _score.ToString();
        }
    }

    private int _highscore;
    public int Highscore
    {
        get
        {
            return _highscore;
        }
        set 
        { 
            _highscore = value; 
            HighScoreText.text = value.ToString();
        }
    }

    private int _lifes;
    public int Lifes
    {
        get
        { 
            return _lifes;
        }
        set
        {
            if (value <= 0)
            {
                GameOver();
            }
            else
            {
                _lifes = value;
                LifesText.text = value.ToString();
              
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
      
        _score = 0;
    }
    private void Start()
    {
        instance.Lifes = Settings.instance.LifeAmount;
        LifesText.text = Lifes.ToString();
        ScoreText.text = Score.ToString();
        LevelIndexText.text = (CurrentLevelIndex + 1).ToString();

        EndGameLabel.SetActive(false);
        EndGameWall.SetActive(false);

        gameOver = false;
        instance.ExtraLifePowerupAmount = 0;
        instance.EnlargePowerUpAmount = 0;

        try
        {
           Highscore = PlayerPrefs.GetInt("HighScore");
        }
        catch (Exception ex)
        {
            Debug.Log($"No highscore found. Excaption occurred: {ex}");
        }

}

    public void SetPauseMenu()
    {

       

        if (!gameOver && !gameEnded)
        {
            SaveButton.interactable = true;
            SaveNotification.SetActive(false);

        }
      

        if (PauseMenu.activeSelf)
        {
            Time.timeScale = 1;
            if (gameEnded)
            {
                EndGameLabel.SetActive(true);
                EndGameWall.SetActive(true);
            }
           

        }
        else
        {
            Time.timeScale = 0;
            MenuScoreText.text = Score.ToString();
            MenuHighScoreText.text = Highscore.ToString();
            if (gameEnded)
            {
                EndGameLabel.SetActive(false);
                EndGameWall.SetActive(false);
            }
           
        }

        PauseMenu.SetActive(!PauseMenu.activeSelf);
    }
    private void Update()
    {
        if (Settings.instance.playerControlls.KeyBoard.Pause.triggered && !gameOver)
        {     
            SetPauseMenu();
      
        }

        TimeToDisplay = Player.instance.currentEnlargeTime;

        if (TimeToDisplay < 0)
        {
            TimeToDisplay = 0;
            TimerObject.SetActive(false);
        }
        else
        { 
            TimerObject.SetActive(true);
        }
           

        TimerText.text = TimeToDisplay.ToString("F2");

    }


    public void GameOver()
    {
        // tutaj porownac wynik do highscora i odmienic jak wiekszy
        GameOverText.SetActive(true);

      
        gameOver = true;

        if (Score > Highscore)
        { 
            Highscore = Score;
        }
        PlayerPrefs.SetInt("HighScore", Highscore);

        ResumeButton.interactable = false;
        SaveButton.interactable = false;

        DataManager.instance.DeleteSaveFile();
        SetPauseMenu();


    }
    public void Retry()
    {
        GameOverText.SetActive(false);
        gameOver = false;
        ResumeButton.interactable = true;
        LoadSceneButton load = new LoadSceneButton();
        int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        load.LoadSceneFormButton(index);
    }

    public void SaveGame()
    {
        if (!gameOver || !gameEnded)
        {
            DataManager.instance.SaveGame();
     
            SaveNotification.SetActive(true);
            SaveButton.interactable = false;
        }
              
    }

    public void NextLevel()
    {
        if (BoardGrid.instance.CheckIfGridIsEmpty())
        {
            GameManager.instance.CurrentLevelIndex++;
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
            if (CurrentLevelIndex == Seed.instance.SeedList.Count)
            {
                EndGameLabel.SetActive(true);
                EndGameWall.SetActive(true);
                SaveButton.interactable = false;
                gameEnded = true;             
            }
            else
            {
                BoardGrid.instance.ResetBoard();
                IDFactory.ResetIDs();
               
                BoardGrid.instance.CreateGrid(Seed.instance.SeedList[CurrentLevelIndex]);
                BallManager.instance.SpawnBall(GameManager.instance.startingBallPosition);

                DataManager.instance.SaveGame();
            }
        }   
        
    }
   

    private void OnDestroy()
    {
        try
        {
            GameOverText.SetActive(false);
            gameOver = false;

        }
        catch (Exception ex)
        { 
            Debug.LogWarning(ex);
        }
    }

    public void LoadData(GameData data)
    {
        this.Score = data.CurrentScore;
       
        this.Lifes = data.PlayerLifes;
        this.CurrentLevelIndex = data.LevelIndex;
    }

    public void SaveData(GameData data)
    {
        data.CurrentScore = this.Score;
       
        data.PlayerLifes = this.Lifes;
        data.LevelIndex = this.CurrentLevelIndex;
    }
}
