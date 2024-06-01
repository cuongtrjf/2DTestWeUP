using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] Transform bulletPosition; 
    public ObjectPool bulletPool;
    public float bulletSpeed = 20f;
    private float timeShoot = 0.1f;
    private float fireTimer;

    private void Awake()
    {
        bulletPool = GameObject.Find("BulletPool").GetComponent<ObjectPool>();
        bulletPosition = GameObject.Find("BulletPosition").GetComponent<Transform>();
    }

    private void Update()
    {
        fireTimer+=Time.deltaTime;
        if (fireTimer >= timeShoot)
        {
            Shoot();
            fireTimer = 0;
        }
    }


    void Shoot()
    {
        GameObject bullet = bulletPool.GetPooledObject();
        SoundEffectManager.Play("Shoot");
        bullet.transform.position = bulletPosition.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletPosition.up * bulletSpeed;
    }
}
