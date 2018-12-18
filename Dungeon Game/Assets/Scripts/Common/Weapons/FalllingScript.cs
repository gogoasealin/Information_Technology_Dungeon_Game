using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalllingScript : MonoBehaviour {

    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
        GetComponentInParent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Falling();
        }
    }



    void Falling()
    {
        rb2d.gravityScale = 1;
        GetComponentInParent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;

    }


}
