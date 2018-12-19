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
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, Time.deltaTime * speed);
        if (transform.position == Vector3.zero)
        {
            player.GetComponent<PlayerController>().enabled = true;
            GetComponent<Boss>().enabled = true;
            GetComponent<BossEnter>().enabled = false;
            GetComponent<Animator>().SetTrigger("stageOne");
        }
    }
}
