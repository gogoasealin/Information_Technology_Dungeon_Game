using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageFour : MonoBehaviour
{

    Transform player;
    private Vector3 playerPos;
    private bool faceRight;
    public bool attack;
    [SerializeField] private bool moving;
    private int nextPosition;
    public Vector3[] positions;
    public GameObject star;
    public GameObject[] lightning;
    private bool threeLightnings;
    private IEnumerator coroutine;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        faceRight = true;

    }


    void Update()
    {
        if (!moving)
        {
            nextPosition = GetNextPosition();
            moving = true;
        }
        MovePosition(nextPosition);
        if (attack)
        {
            coroutine = LightningStrike();
            StartCoroutine(coroutine);
            attack = false;
        }
    }

    IEnumerator LightningStrike()
    {
        int random = Random.Range(0, 2);
        if(random == 0)
        {
            for (int i = 0; i < lightning.Length ;++i)
            {
                lightning[i].SetActive(true);
                yield return new WaitForSeconds(0.3f);
            }
        }
        else
        {
            for (int i = lightning.Length-1; i >= 0; --i)
            {
                lightning[i].SetActive(true);
                yield return new WaitForSeconds(0.3f);
            }
        }
        Invoke("StartAnimation", 1f);
    }

    public int GetNextPosition()
    {
        return Random.Range(0, positions.Length);
    }

    public void MovePosition(int nextPosition)
    {
        CheckRotate(positions[nextPosition]);
        transform.position = Vector2.MoveTowards(transform.position, positions[nextPosition], 1 * Time.deltaTime);
        if (transform.position == positions[nextPosition])
        {
             moving = false;      
        }
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
