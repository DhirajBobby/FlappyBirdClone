using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    [SerializeField]
    GameObject MainMenuMuteButton;
    
    private void Awake()
    {
        instance = this;

        //check if muted then update toggle button accordingly without calling onValueChanged function
        int IsMuted = PlayerPrefs.GetInt("IsMuted", 0);
        switch (IsMuted)
        {
            case 0:
                MainMenuMuteButton.GetComponent<Toggle>().SetIsOnWithoutNotify(true);
                break;
            case 1:
                MainMenuMuteButton.GetComponent<Toggle>().SetIsOnWithoutNotify(false);
                break;
        }
    }

    //Loads GameScene
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    //checks toggle value and play/pause BGM and set isMuted value
    public void MuteToggle()
    {
        if (MainMenuMuteButton.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("IsMuted",0);
            BGMManager.instance.PlayBGM();
        }
        else
        {
            PlayerPrefs.SetInt("IsMuted", 1);
            BGMManager.instance.PauseBGM();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}