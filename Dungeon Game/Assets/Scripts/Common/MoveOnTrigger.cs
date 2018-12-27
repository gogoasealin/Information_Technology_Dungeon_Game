using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTrigger : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private GameController gameController;
    private int triggerNumber;



    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().enabled = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (triggerNumber == 0)
            {
                Shot();
                triggerNumber++;
            }
            else
            {
                gameController.GameOver();
            }
        }
    }

    private void Shot()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
        rb2d.AddForce(transform.right * speed);
    }
}
