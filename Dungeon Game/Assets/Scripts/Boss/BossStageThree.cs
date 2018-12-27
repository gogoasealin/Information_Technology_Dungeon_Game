using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageThree : MonoBehaviour
{

    Transform player;
    private Vector3 playerPos;
    private bool faceRight;
    public bool attack;
    public GameObject star;
    public GameObject[] lightning;
    private bool threeLightnings;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        faceRight = true;
    }

    void Update()
    {
        MovePosition();
        CheckRotate(playerPos);
        if (attack)
        {
            if (threeLightnings)
            {
                lightning[0].SetActive(true);
                lightning[1].SetActive(true);
                lightning[2].SetActive(true);
                threeLightnings = false;
            }
            else
            {
                lightning[3].SetActive(true);
                lightning[4].SetActive(true);
                threeLightnings = true;
            }
            lightning[5].SetActive(true);
            lightning[6].SetActive(true);
            Invoke("StartAnimation",1f);
            attack = false;
        }
    }

    public void MovePosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector3.zero, 1 * Time.deltaTime);
    }

    private void CheckRotate(Vector3 position)
    {
        if (transform.position != position)
        {
            if (transform.position.x > position.x && faceRight)
            {
                transform.transform.Rotate(0f, 180f, 0f);
                faceRight = false;
            }
            else if (transform.position.x < position.x && !faceRight)
            {
                transform.transform.Rotate(0f, 180f, 0f);
                faceRight = true;
            }
        }
    }

    public void StartAnimation()
    {
        star.SetActive(true);
    }

    public void SetPlayerPos()
    {
        playerPos = player.position;
        CheckRotate(playerPos);
    }
}
