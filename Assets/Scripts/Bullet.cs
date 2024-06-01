using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    public ObjectPool pool;
    private int damage = 1;

    bool stateReceiveDamage = false;

    private void Awake()
    {
        ObjectFormation.onStateReceiveDamage += SetStateReceiveDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BulletBound"))
            gameObject.SetActive(false);
        else if (collision.gameObject.CompareTag("Enemy") && stateReceiveDamage)
        {
            gameObject.SetActive(false);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            SoundEffectManager.Play("Explosion");
        }
    }


    void SetStateReceiveDamage()
    {
        stateReceiveDamage = true;
    }

}
