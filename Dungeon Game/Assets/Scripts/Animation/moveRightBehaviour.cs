using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRightBehaviour : StateMachineBehaviour
{
    float timer;
    public float minTime;
    public float maxTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = stateInfo.length;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                animator.SetTrigger("idle");
            }
            else
            {
                animator.SetTrigger("moveLeft");
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }

    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //    int random = Random.Range(0, 2);
    //    if (random == 0)
    //    {
    //        animator.SetTrigger("idle");
    //    }
    //    else
    //    {
    //        animator.SetTrigger("moveLeft");
    //    }
    //}

}
