using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public static event Action onEnemyDie;
    [SerializeField] int maxHP = 5;
    private int currentHP;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Score.IncreaseScore();
        onEnemyDie.Invoke();
        gameObject.SetActive(false);
    }
}
