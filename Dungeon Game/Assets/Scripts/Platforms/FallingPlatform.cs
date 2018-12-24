using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    private int moveSpeed = 10;
    private bool go;
    private Vector3 goPosition;
    private float timer;

    private void Start()
    {
        goPosition = gameObject.transform.position + new Vector3(0F, -100f, 0f);
    }

    private void Update()
    {
        if (go)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, goPosition, Time.deltaTime * moveSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            go = true;
        }
    }

}
