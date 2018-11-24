using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScript : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private GameObject gameController;
    private GameController gameManagerScript;
    private int triggerNumber;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameController.GetComponent<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (triggerNumber == 0)
            {
                Roll();
                Destroy(GetComponentInChildren<BoxCollider2D>());
                triggerNumber++;
            }
            else
            {
                gameManagerScript.GameOver();
            }
        }
    }

    public void Roll()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        rb2d.AddForce(transform.right * speed);
        rb2d.angularVelocity = 400;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
