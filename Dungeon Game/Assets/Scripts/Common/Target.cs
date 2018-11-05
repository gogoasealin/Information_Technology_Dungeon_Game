using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GameObject wall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shuriken")
        {
            if (wall.GetComponent<WallRemove>() != null)
            {
                wall.GetComponent<WallRemove>().RemoveWall();
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
