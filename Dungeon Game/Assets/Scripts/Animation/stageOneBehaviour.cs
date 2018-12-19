using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageOneBehaviour : StateMachineBehaviour
{
    private int rand;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 3);

        if (rand == 0)
        {
            animator.SetTrigger("idle");
        }
        else if (rand == 1)
        {
            animator.SetTrigger("moveRight");
        }
        else
        {
            animator.SetTrigger("moveLeft");
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
