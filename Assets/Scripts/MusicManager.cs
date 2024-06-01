using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;
    public AudioClip backgroundMusic;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        if (backgroundMusic != null)
        {
            PlayerBackgroundMusic(backgroundMusic);
        }
    }

    public static void PlayerBackgroundMusic(AudioClip audioClip = null)
    //neu reset game thi reset lai music,tham so audioclip=null dc hieu no co the co hoac khong truyen vao
    {
        if (audioClip != null)//neu dc truyen vao bai hat moi thi audiosource= cai do
        {
            instance.audioSource.clip = audioClip;
        }
        if (instance.audioSource.clip != null)
        {
            instance.audioSource.Play();
        }
    }

    public static void StopBackgroundMusic()
    {
        instance.audioSource.Stop();
    }
}
