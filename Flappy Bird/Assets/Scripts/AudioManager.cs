using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    AudioSource SFXAudioSource;
    Dictionary<AudioClipName, AudioClip> AudioClips = new Dictionary<AudioClipName, AudioClip>();
    [SerializeField]
    AudioClip BirdJumpSound;
    [SerializeField]
    AudioClip BirdDieSound;
    [SerializeField]
    AudioClip ScorePointSound;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        SFXAudioSource = GetComponent<AudioSource>();
        AudioClips.Add(AudioClipName.BirdJump, BirdJumpSound);
        AudioClips.Add(AudioClipName.BirdDie, BirdDieSound);
        AudioClips.Add(AudioClipName.ScorePoint, ScorePointSound);
        
    }

    //Plays SFX only is not muted
    public void PlaySound(AudioClipName ClipName)
    {
        if (SFXAudioSource && PlayerPrefs.GetInt("IsMuted",0)==0)
        {
            SFXAudioSource.PlayOneShot(AudioClips[ClipName]);
        }
    }
}
