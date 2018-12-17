using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private GameObject player;
    private PlayerController playerControllerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = player.GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
        if (playerControllerScript.facingRight)
        {
            rb2d.AddForce(transform.right * speed);
            rb2d.angularVelocity = 200f;
        }else
        {
            rb2d.AddForce(-transform.right * speed);
            rb2d.angularVelocity = 200f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Ground" || other.tag == "Breakable" || other.tag == "Climbable" || other.tag == "Environment")
        if (other.tag == "Breakable" || other.tag == "Climbable" || other.tag == "Environment")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
