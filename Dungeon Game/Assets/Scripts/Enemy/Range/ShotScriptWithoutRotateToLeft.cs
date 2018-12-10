using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScriptWithoutRotateToLeft : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private GameObject gameController;
    private GameController gameManagerScript;
    private GameObject player;
    private float timer;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameController.GetComponent<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(-transform.right * speed);
        rb2d.angularVelocity = 200f;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 4f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManagerScript.GameOver();
        }
    }



    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}