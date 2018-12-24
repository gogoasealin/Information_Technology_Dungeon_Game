using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageTwo : MonoBehaviour
{
    Transform parent;
    Animator anim;

    [SerializeField] private bool attack;
    [SerializeField] private bool moving;
    [SerializeField] Transform arrowPosition;
    private int nextPosition;
    public Vector3[] positions;

    Transform player;
    private Vector3 playerPos;
    private bool wasIdle;
    private bool onceIdle;
    private bool faceRight;
    public GameObject bossArrow;

    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Boss").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        onceIdle = true;
        faceRight = true;
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (!moving)
            {
                nextPosition = GetNextPosition();
                moving = true;
                wasIdle = true;
            }
            MovePosition(nextPosition);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("ArrowAttack"))
        {
            if (attack && wasIdle)
            {
                Instantiate(bossArrow, arrowPosition.position , Quaternion.identity);
                wasIdle = false;
            }
        }

    }

    private void CheckRotate(Vector3 position)
    {
        if (parent.position != position)
        {
            if (parent.position.x > position.x && faceRight)
            {
                parent.transform.Rotate(0f, 180f, 0f);
                faceRight = false;
            }
            else if (parent.position.x < position.x && !faceRight)
            {
                parent.transform.Rotate(0f, 180f, 0f);
                faceRight = true;
            }
        }
    }

    public int GetNextPosition()
    {
        return Random.Range(0, positions.Length);

    }

    public void MovePosition(int nextPosition)
    {
        CheckRotate(positions[nextPosition]);
        parent.position = Vector2.MoveTowards(parent.position, positions[nextPosition], 1 * Time.deltaTime);

        if (parent.position == positions[nextPosition])
        {
            if (onceIdle)
            {
                Invoke("SetAttack", 1f);
                moving = false;
                onceIdle = false;
            }

        }
    }

    public void Attack()
    {
        attack = true;
    }

    public void StopAttack()
    {
        attack = false;
        Invoke("SetIdle", 0.5f);
    }

    public void SetPlayerPos()
    {
        playerPos = player.position;
        CheckRotate(playerPos);
    }

    public void SetIdle()
    {
        anim.SetTrigger("Idle");
    }

    public void SetAttack()
    {
        anim.SetTrigger("Attack");
        onceIdle = true;
    }
}
