using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnter : MonoBehaviour
{
    private GameObject player;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.localScale += new Vector3(0.001f, 0.001f, 0);
        if (transform.localScale.x >= 0.03f)
        {
            transform.localScale = new Vector3(0.03f, 0.03f, 0);
            player.GetComponent<PlayerController>().enabled = true;
            GetComponent<Boss>().enabled = true;
            //GetComponent<Animator>().enabled = true;
            GetComponent<BossEnter>().enabled = false;

        }
    }
}
