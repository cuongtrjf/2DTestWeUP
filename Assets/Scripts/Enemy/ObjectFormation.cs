using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectFormation : MonoBehaviour
{
    public static event Action onStateReceiveDamage;
    
    public GameObject objectPrefab; 
    public GameObject startPoint;
    private int gridSize = 4; //size doi tuong
    [SerializeField] float spacing = 0.5f; //khoang cach giua cac doi tuong


    private Vector2 startSquare = new Vector2(-1.5f, 4f);//vi tri dau tien cua object hinh vuong

    private Vector2 startDiamond = new Vector2(0f, 2.5f);//vi tri dau tien cua object hinh thoi

    private Vector2 startRectangle = new Vector2(-1.5f, 3f); //vi tri dau tien cua object hinh chu nhat
    
    private int rectangleRows = 3;//so luong object theo chieu rong va dai cua object hinh chu nhat
    private int rectangleCols = 7;

    private List<GameObject> objects = new List<GameObject>();

    void Start()
    {
        //khoi tao cac doi tuong o ben ngoai
        for (int i = 0; i < gridSize * gridSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab, startPoint.transform.position, Quaternion.identity);
            obj.transform.parent = transform;
            objects.Add(obj);
        }
        //di chuyen vao ben trong tao hinh vuong
        StartCoroutine(MoveToSquareFormation());
    }

    IEnumerator MoveToSquareFormation()//move cac object tao hinh vuong
    {
        for (int i = 0; i < objects.Count; i++)
        {
            Vector3 squarePosition = CalculateSquarePosition(i);
            StartCoroutine(MoveObject(objects[i], squarePosition));
        }

        //cho 2 giay de cac doi tuong di chuyen tao hinh vuong
        yield return new WaitForSeconds(2f);

        //cho 5s truoc khi di chuyen thanh hinh vuong
        yield return new WaitForSeconds(5f);

        //di chuyen vao hinh thoi
        for (int i = 0; i < objects.Count; i++)
        {
            Vector3 diamondPosition = CalculateDiamondPosition(i);
            StartCoroutine(MoveObject(objects[i], diamondPosition));
        }

        yield return new WaitForSeconds(2f);


        //cho 5s de di chuyen vao hinh tam giac
        yield return new WaitForSeconds(5f);

        //di chuyen tao tam giac can
        List<Vector3> listPosition = CalculateTrianglePosition();
        for (int i = 0; i < objects.Count; i++)
        {
            Vector3 trianglePosition = listPosition[i];
            StartCoroutine(MoveObject(objects[i], trianglePosition));
        }

        yield return new WaitForSeconds(2f);

        yield return new WaitForSeconds(5f);

        for (int i = 0; i < objects.Count; i++) 
        {
            Vector3 rectanglePosition = CalculateRectanglePosition(i);
            StartCoroutine(MoveObject(objects[i], rectanglePosition));
        }

        yield return new WaitForSeconds(3f);//sau khi da hoan thanh cac doi hinh thi se nhan damage
        onStateReceiveDamage.Invoke();
    }

    Vector3 CalculateSquarePosition(int index)
    {
        //chuyen chi so index thanh toa do hang va cot
        int row = index / gridSize;
        int col = index % gridSize;

        //tinh toan vi tri cua hinh vuong
        float x = startSquare.x + col * spacing;
        float y = startSquare.y - row * spacing;
        return new Vector3(x, y, 0);
    }

    Vector3 CalculateDiamondPosition(int index)
    {
        spacing = 0.75f;
        //chuyen chi so index thanh toa do hang va cot
        int row = index / gridSize;
        int col = index % gridSize;

        //tinh toan vi tri cac object cua hinh thoi
        float x = startDiamond.x + (col - row) * spacing;
        float y = startDiamond.y + (col + row - (gridSize - 1)) * spacing * 0.5f;
        return new Vector3(x, y, 0);
    }


    List<Vector3> CalculateTrianglePosition()//tinh toan cac vi tri cua object tao hinh tam giac
    {
        List<Vector3> listPosition = new List<Vector3>();
        int h = 5;
        Vector3 temp = new Vector3(-2.5f, 4f, 0);
        for (int i = 1; i <= h; i++)
        {
            temp.x = -2.5f;
            for (int j = 1; j < 2 * h; j++)
            {
                if (Mathf.Abs(h - j) == i - 1 || i == h)
                {
                    temp.x += 0.5f;
                    listPosition.Add(temp);
                }
                else
                {
                    temp.x += 0.5f;
                }
            }
            temp.y -= 0.5f;
        }
        return listPosition;
    }


    Vector3 CalculateRectanglePosition(int index)//tinh toan vitri cac object tao hinh chu nhat
    {
        spacing = 0.5f;
        if (index < rectangleCols)
        {
            //cac doi tuong cua canh tren
            float x = startRectangle.x + index * spacing;
            float y = startRectangle.y;
            return new Vector3(x, y, 0);
        }
        else if (index < rectangleCols + rectangleRows - 1)
        {
            //cac doi tuong canh ben phai
            int sideIndex = index - rectangleCols;
            float x = startRectangle.x + (rectangleCols - 1) * spacing;
            float y = startRectangle.y - (sideIndex + 1) * spacing;
            return new Vector3(x, y, 0);
        }
        else if (index < 2 * rectangleCols + rectangleRows - 2)
        {
            //cac doi tuong canh duoi
            int sideIndex = index - (rectangleCols + rectangleRows - 1);
            float x = startRectangle.x + (rectangleCols - 1) * spacing - (sideIndex + 1) * spacing;
            float y = startRectangle.y - (rectangleRows - 1) * spacing;
            return new Vector3(x, y, 0);
        }
        else
        {
            //cac doi tuong canh ben trai
            int sideIndex = index - (2 * rectangleCols + rectangleRows - 2);
            float x = startRectangle.x;
            float y = startRectangle.y - (rectangleRows - 1) * spacing + (sideIndex + 1) * spacing;
            return new Vector3(x, y, 0);
        }
    }


    IEnumerator MoveObject(GameObject obj, Vector3 targetPosition)
    {
        float duration = 2f; //thoi gian cac doi tuong di chuyen vao vi tri
        Vector3 startPosition = obj.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition;
    }
}
