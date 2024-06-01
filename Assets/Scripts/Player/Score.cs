using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score : MonoBehaviour
{
    public static event Action onComplete;

    private static Score instance;

    private int score;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;
    }

    public static void IncreaseScore()
    {
        instance.score += 1;
        if (instance.score == 16)
        {
            onComplete.Invoke();
        }
    }

    public static int GetScore()
    {
        return instance.score;
    }
}
