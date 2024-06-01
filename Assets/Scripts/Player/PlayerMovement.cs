using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    public float moveSpeed = 5f;


    float horizontalMovement;
    float verticalMovement;


    //bounds
    float maxX, maxY;
    float minX, minY;
    float widthPlayer;
    float heightPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));//chuyen doi toa do man hinh sang toa do 3d

        widthPlayer = spriteRenderer.bounds.size.x;
        heightPlayer = spriteRenderer.bounds.size.y;

        minX = -bounds.x;
        minY = -bounds.y;
        maxX = bounds.x;
        maxY = bounds.y;
    }

    // Update is called once per frame
    void Update()
    {
        //bounds
        Vector3 temp = transform.position;

        if(temp.x - widthPlayer/2 < minX)
        {
            temp.x = minX + widthPlayer/2;
        }else if (temp.x + widthPlayer/2 > maxX)
        {
            temp.x = maxX - widthPlayer/2;
        }

        if (temp.y - heightPlayer/2 < minY)
        {
            temp.y = minY + heightPlayer/2;
        }
        else if (temp.y + heightPlayer/2 > maxY)
        {
            temp.y = maxY - heightPlayer/2;
        }

        transform.position = temp;
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
    }


    public void MoveHorizontal(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void MoveVertical(InputAction.CallbackContext context)
    {
        verticalMovement = context.ReadValue<Vector2>().y;
    }
}
