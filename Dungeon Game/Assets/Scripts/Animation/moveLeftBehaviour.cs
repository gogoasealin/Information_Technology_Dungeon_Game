using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeftBehaviour : StateMachineBehaviour
{
    float timer;
    public float minTime;
    public float maxTime;

    //private Transform playerPos;
    //private float speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = stateInfo.length;

        //playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                animator.SetTrigger("moveRight");
            }
            else
            {
                animator.SetTrigger("idle");
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }

        //Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);

        //animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            animator.SetTrigger("moveRight");
        }
        else
        {
            animator.SetTrigger("idle");
        }
    }
}
