using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private GameController gameControllerScript;

    private void Start()
    {
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnDisable()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameControllerScript.GameOver();
        }
    }
}
