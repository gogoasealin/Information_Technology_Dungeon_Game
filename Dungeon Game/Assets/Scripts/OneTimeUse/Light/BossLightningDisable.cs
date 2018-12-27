using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLightningDisable : MonoBehaviour
{
    private GameController gameControllerScript;

    private void Start()
    {
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void OnEnable()
    {
        Handheld.Vibrate();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            gameControllerScript.GameOver();
        }
    }

}
