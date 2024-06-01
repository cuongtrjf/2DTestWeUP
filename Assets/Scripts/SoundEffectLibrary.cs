using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField]
    private SoundEffectGroup[] soundEffectGroups;

    private Dictionary<string, AudioClip> soundDictionary;
    //dung dictionary de luu cac du lieu am thanh la tot nhat theo dang key, list audio
    //vi du: key=player, list audio se la: nhay, chet, ...
    //vi dictionary k the thao tac tren inspector cua unity nen phai tao 1 ham de thao tac


    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        soundDictionary = new Dictionary<string, AudioClip>();
        foreach (SoundEffectGroup soundEffectItem in soundEffectGroups)
        {
            soundDictionary[soundEffectItem.name] = soundEffectItem.audioClip;//sounddictionanry[key]=value -> ta co dictionaray[key,value]
        }
    }

    public AudioClip GetClip(string key)
    {
        if (soundDictionary.ContainsKey(key))
        {
            return soundDictionary[key];
        }
        return null;
    }
}


[System.Serializable]
public struct SoundEffectGroup
{
    public string name;
    public AudioClip audioClip;
}
