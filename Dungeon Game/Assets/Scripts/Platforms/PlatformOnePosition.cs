using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOnePosition : MonoBehaviour
{
    public Vector3 platformNextPosition;

    public float moveSpeed;

    private void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, platformNextPosition, Time.deltaTime * moveSpeed);
    }
}
