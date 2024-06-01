using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;//object to pool
    public int poolSize = 16;
    private List<GameObject> pool;



    // Start is called before the first frame update
    void Start()
    {
        InitializePool();//khoi tao pool
    }

    private void InitializePool()
    {
        pool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            CreateNewObj();
        }
    }


    public GameObject GetPooledObject()//muc dich tra ve doi tuong dang k hoat dong de su dung no, neu k co doi tuong nao thi tao moi
    {
        foreach(GameObject obj in pool)
        {
            //check xem object co dang k dc active tren hirachi k
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return CreateNewObj();
    }

    private GameObject CreateNewObj()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }
}
