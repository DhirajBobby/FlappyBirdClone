using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    AudioSource BGMAudiosource;

    private void Awake()
    {
        //create an instance and make object available in all scenes
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        BGMAudiosource = GetComponent<AudioSource>();
        BGMAudiosource.Play();
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        int IsMuted = PlayerPrefs.GetInt("IsMuted", 0);
        if(IsMuted==1)
            PauseBGM();
    }

    //Pauses BGM only
    public void PauseBGM()
    {
        BGMAudiosource.Pause();
    }

    //Plays BGM only
    public void PlayBGM()
    {
        BGMAudiosource.UnPause();
    }
}
