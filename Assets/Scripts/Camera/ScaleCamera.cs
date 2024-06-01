using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCamera : MonoBehaviour
{
    float worldHeight;
    float worldWidth;



    // Start is called before the first frame update
    void Start()
    {
        worldHeight = Camera.main.orthographicSize * 2;//lay dc chieu dai cua camera de scale theo
        worldWidth = worldHeight * Screen.width / Screen.height;//tinh dc chieu rong dua theo cong thuc

        transform.localScale = new Vector3(worldWidth, worldHeight, 0f);
    }

}
