using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerVisibleOnly : MonoBehaviour
{
    private GameController gameControllerScript;

    private void Awake()
    {
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && GetComponentInParent<SpriteRenderer>().enabled)
        {
            gameControllerScript.GameOver();
        }
    }
}
