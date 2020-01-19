using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMove : MonoBehaviour
{
    public float speed = 2.0f;
    public float xPos;
    public float yPos;
    public float zPos;
    public float startPosX;
    public float startPosY;
    public float startPosZ;
    public float moveRange;
    public Vector3 desiredPos;
    public float timer;
    public float timerSpeed;
    public float timeToMove;
    void Start()
    {
        xPos = Random.Range(startPosX, startPosX +moveRange);
        yPos = Random.Range(startPosY, startPosY + moveRange);
        zPos = Random.Range(startPosZ, startPosZ + moveRange);
        desiredPos = new Vector3(xPos, yPos, zPos);
    }

    void Update()
    {
        timer += Time.deltaTime * timerSpeed;
        if (timer >= timeToMove)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * speed);
             if (Vector3.Distance(transform.position, desiredPos) <= 0.01f)
            {
                xPos = Random.Range(startPosX, startPosX + moveRange);
                yPos = Random.Range(startPosY, startPosY + moveRange);
                zPos = Random.Range(startPosZ, startPosZ + moveRange);
                desiredPos = new Vector3(xPos, yPos, zPos);
                timer = 0.0f;
            }
        }
    }
}