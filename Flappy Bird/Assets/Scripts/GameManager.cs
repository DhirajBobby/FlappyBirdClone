using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    Text ScoreText;
    [SerializeField]
    Text HighscoreText;
    [SerializeField]
    Image Game;
    [SerializeField]
    Image Over;
    [SerializeField]
    Image NewHighscore;
    [SerializeField]
    GameObject PlayButton;
    [SerializeField]
    GameObject MainMenuButton;
    [SerializeField]
    GameObject StartGameButton;
    [SerializeField]
    GameObject GameMuteButton;
    
    int score = 0;
    [HideInInspector]
    public GameState gameState;

    private void Awake()
    {
        Instance = this;
        HighscoreText.text = "Highscore " + PlayerPrefs.GetInt("Highscore",0).ToString();
        Application.targetFrameRate = 60;
        StopGame();
        gameState = GameState.TapToStart;

        //check if muted then update toggle button accordingly without calling onValueChanged function
        int IsMuted = PlayerPrefs.GetInt("IsMuted", 0);
        switch (IsMuted)
        {
            case 0:
                GameMuteButton.GetComponent<Toggle>().SetIsOnWithoutNotify(true);
                break;
            case 1:
                GameMuteButton.GetComponent<Toggle>().SetIsOnWithoutNotify(false);
                break;
        }
    }

    //Add score and check if it's a highscore
    public void AddScore()
    {
        score++;
        if (score > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", score);
            HighscoreText.text = "Highscore " + PlayerPrefs.GetInt("Highscore").ToString();
            NewHighscore.enabled = true;
        }
        ScoreText.text = score.ToString();
    }

    //Called when bird dies.
    public void GameOver()
    {
        Time.timeScale = 0;
        Game.enabled = true;
        Over.enabled = true;
        MainMenuButton.SetActive(true);
        PlayButton.SetActive(true);
        gameState = GameState.GameOver;
    }

    //Called when game paused and on the first load
    public void StopGame()
    {
        Time.timeScale = 0;
        StartGameButton.SetActive(true);
    }

    //Begin playing
    public void StartGame()
    {
        Time.timeScale = 1;
        StartGameButton.SetActive(false);
        gameState = GameState.Playing;
    }

    //Reloads game scene
    public void Play()
    {
        score = 0;
        ScoreText.text = score.ToString();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    //Loads Main Menu
    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    //Pauses game.Goes to tap to start stage.Can be used to display pause pop-up.
    public void Pause() 
    {
        if (gameState == GameState.Playing || gameState == GameState.TapToStart)
        {
            gameState = GameState.Paused;
            StopGame();
        }
    }

    //checks toggle value and play/pause BGM and set isMuted value
    public void MuteToggle()
    {
        if (GameMuteButton.GetComponent<Toggle>().isOn)
        {
            BGMManager.instance.PlayBGM();
            PlayerPrefs.SetInt("IsMuted", 0);
        }
        else
        {
            BGMManager.instance.PauseBGM();
            PlayerPrefs.SetInt("IsMuted", 1);
        }
    }
}
