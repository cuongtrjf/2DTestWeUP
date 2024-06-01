using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager instance;
    //tao 1 the hien duy nhat
    private static AudioSource audioSource;//1 thanh phan trong component de dieu khien audioclip(1 dai dien cho am thanh dc gan vao)
    private static SoundEffectLibrary soundEffectLibrary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;//dam bao rang no la duy nhat
            audioSource = GetComponent<AudioSource>();
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            DontDestroyOnLoad(gameObject);//dam bao no se k bi pha huy khi tai scence moi
        }
        else
        {
            Destroy(gameObject);//neu da co 1 the hien thi pha huy doi tuong
        }
    }


    public static void Play(string soundName)
    {
        AudioClip audioClip = soundEffectLibrary.GetClip(soundName);
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);//phat am thanh 1 lan
        }
    }
}
