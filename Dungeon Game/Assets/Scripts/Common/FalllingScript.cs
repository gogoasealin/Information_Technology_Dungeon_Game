using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalllingScript : MonoBehaviour {

    private Rigidbody2D rb2d;
    private GameObject gameController;
    private GameController gameManagerScript;
    private int triggerNumber;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameController.GetComponent<GameController>();
        triggerNumber = 0;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (triggerNumber == 0)
            {
                Falling();
                triggerNumber++;
            }
            else
            {
                gameManagerScript.GameOver();
            }
           
        }
    }
    

    void Falling()
    {
        rb2d.gravityScale = 1;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }



    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
