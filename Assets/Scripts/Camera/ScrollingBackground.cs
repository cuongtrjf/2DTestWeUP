using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollingSpeed = 1f;
    private Material material;//gan material background vao
    private Vector2 offset = Vector2.zero;


    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = material.mainTextureOffset;

    }

    // Update is called once per frame
    void Update()
    {
        offset.y += scrollingSpeed * Time.deltaTime;//toc do scroll background
        material.SetTextureOffset("_MainTex", offset);
    }
}
