using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveMorePosition : MonoBehaviour {

    
    public Vector3[] platformPosition;

    public float moveSpeed;

    private Vector3 nextPosition;
    private bool go;
    private int positionNumber;

    private void Awake()
    {
        positionNumber = 0;
        nextPosition = platformPosition[positionNumber];
    }

    private void Update()
    {
        if(go)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPosition, Time.deltaTime * moveSpeed);
            if (gameObject.transform.position == nextPosition)
            {
                positionNumber++;
                if (positionNumber == platformPosition.Length)
                {
                    Destroy(gameObject);
                }
                else
                {
                    nextPosition = platformPosition[positionNumber];
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            go = true;
        }
    }
}
