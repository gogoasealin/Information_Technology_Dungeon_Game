using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private GameController gameController;
    private GameObject player;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        var dir = player.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb2d.AddForce(transform.right * speed);
        rb2d.angularVelocity = 200f;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameController.GameOver();
        }
        if(other.gameObject.tag == "Shuriken")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }



    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
