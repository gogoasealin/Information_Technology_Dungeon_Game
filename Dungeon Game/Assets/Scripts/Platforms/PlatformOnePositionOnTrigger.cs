using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformOnePositionOnTrigger : MonoBehaviour
{
    public Vector3 platformNextPosition;

    public float moveSpeed;

    private bool go;

    private void Update()
    {
        if (go)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, platformNextPosition, Time.deltaTime * moveSpeed);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            go = true;
        }
    }
}
