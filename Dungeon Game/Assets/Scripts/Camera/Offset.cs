using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Offset : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 3f, 0f);
        }
    }
}
