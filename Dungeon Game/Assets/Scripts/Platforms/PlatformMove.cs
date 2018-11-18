using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    public float moveSpeed;

    private Vector3 startPosition;
    private Vector3 nextPosition;
    private Vector3 goPosition;
    public Vector3 clampStartPosition;
    public Vector3 clampNextPosition;


    void Start()
    {
        startPosition = gameObject.transform.position + clampStartPosition;
        nextPosition = gameObject.transform.position + clampNextPosition;
        goPosition = nextPosition;
    }


    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, goPosition, Time.deltaTime * moveSpeed);
        if (gameObject.transform.position == goPosition)
        {
            if(gameObject.transform.position == startPosition)
            {
                goPosition = nextPosition;
            }
            else
            {
                goPosition = startPosition;
            }
        }
    }

}
