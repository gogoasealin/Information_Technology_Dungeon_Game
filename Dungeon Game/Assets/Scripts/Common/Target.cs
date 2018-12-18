using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GameObject wall;

    private bool isColliding = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shuriken")
        {
            if (isColliding) return; // stop double colliding 
            isColliding = true;
            if (wall != null)
            {
                wall.GetComponent<WallRemove>().RemoveWall();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}
