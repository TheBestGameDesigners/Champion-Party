using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour
{

    public GameObject player;

    private Vector3 cameraPos;
    private Vector3 oldPosition;
    private float height;
    private float width;
    private float borderLeft;
    private float borderRigth;
    private float borderUp;
    private float borderDown;

    void Start()
    {
        // transform.position = player.transform.position;
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        resetBorders();
        oldPosition = player.transform.position;
    }

    void resetBorders(){
        cameraPos = transform.position;
        borderLeft = cameraPos.x - width / 2;
        borderRigth = cameraPos.x + width / 2;
        borderUp = cameraPos.y - height / 2;
        borderDown = cameraPos.y + height / 2;
    }

    void FixedUpdate ()
    {
        Vector3 v3 = player.transform.position;

        if (v3.x > borderRigth)
        {
            moveRight(v3);
        }
        if (v3.x < borderLeft)
        {
            moveLeft(v3);
        }
        if (v3.y > borderDown)
        {
            moveDown(v3);
        }
        if (v3.y < borderUp)
        {
            moveUp(v3);
        }
        resetBorders();
    }

    void moveRight(Vector3 v3)
    {
        Vector3 newPos = transform.position;
        newPos.x = transform.position.x + borderRigth - v3.x;
        transform.position = newPos;
    }

    void moveLeft(Vector3 v3)
    {
        Vector3 newPos = transform.position;
        newPos.x = transform.position.x - borderLeft - v3.x;
        transform.position = newPos;
    }

    void moveDown(Vector3 v3)
    {
        Vector3 newPos = transform.position;
        newPos.y = transform.position.y + (borderDown - v3.y);
        transform.position = newPos;
    }

    void moveUp(Vector3 v3)
    {
        Vector3 newPos = transform.position;
        newPos.y = transform.position.y - borderUp - v3.y;
        transform.position = newPos;
    }
}