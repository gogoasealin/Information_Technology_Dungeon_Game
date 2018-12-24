using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageOne : MonoBehaviour
{
    Transform parent;
    Animator anim;

    [SerializeField] private bool attack;
    [SerializeField]private bool moving;
    float speed ;
    private int nextPosition;
    public Vector3[] positions;

    Transform player;
    private Vector3 playerPos;
    private bool wasIdle;
    private bool onceIdle;
    public float timeToReachTarget;
    void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Boss").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        onceIdle = true;
    }
    
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if(!moving)
            {
                nextPosition = GetNextPosition();
                moving = true;
                wasIdle = true;
            }
            MovePosition(nextPosition);
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("AxeAttack"))
        {
            if(attack && wasIdle)
            {
                parent.position =  Vector3.Lerp(parent.position, playerPos, timeToReachTarget);
                //parent.position = Vector2.MoveTowards(parent.position, playerPos, 3f * Time.deltaTime);
            }
        }

    }


    public int GetNextPosition()
    {
        return Random.Range(0, positions.Length);

    }

    public void MovePosition(int nextPosition)
    {
        parent.position = Vector2.MoveTowards(parent.position, positions[nextPosition], 1 * Time.deltaTime);
        if(parent.position == positions[nextPosition])
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

    public void SetPlayerPos()
    {
        playerPos = player.position;
    }

    public void StopAttack()
    {
        attack = false;
        wasIdle = false;
        Invoke("SetIdle", 1f);
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
