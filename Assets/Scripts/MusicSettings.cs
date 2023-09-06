using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicSettings : MonoBehaviour
{
    AudioSource BackgroundMusic;
    [SerializeField] GameObject X;

    private void Start()
    {
        BackgroundMusic = AudioManager.Instance.BackgroundMusic;
        X.SetActive(false);
    }
    public void Mute_Unmute ()
    {
        if (BackgroundMusic.isPlaying)
        {
            X.SetActive(true);
            BackgroundMusic.Pause();
        }
        else 
        {
            X.SetActive(false);
            BackgroundMusic.Play();
        }
    }
}
