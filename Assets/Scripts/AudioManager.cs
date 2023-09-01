using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource Audio;

    public AudioSource MoveSound;
    public AudioSource BackgroundMusic;

    public AudioClip Umph;
    public AudioClip ButtonClick;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    private void PlaySound(AudioClip a) { Audio.PlayOneShot(a); }

    public void PlayButtonClickSound() { PlaySound(ButtonClick); }

    public void PlayUmphSound() { PlaySound(Umph); }
}
