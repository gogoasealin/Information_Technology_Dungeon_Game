using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Vector3 nextPosition;
    private bool moving;
    private bool changeForm;

    public float speed;
    public float attackTime;
    public float changeFormDuration;

    



    private void Start()
    {
        nextPosition = Vector3.zero;
        moving = true;
        changeFormDuration = 0.1f;
        StartCoroutine(BossEntrance());
    }

    private void Update()
    {
        if(!moving) {return;}
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, Time.deltaTime * speed);
        if (transform.position == nextPosition)
        {
            moving = false;
        }
    }

    private IEnumerator BossEntrance()
    {
        while(transform.position == nextPosition)
        {
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(changeFormDuration);
        StartCoroutine(FirstForm());
    }

    private IEnumerator FirstForm()
    {
        while(!changeForm)
        {

            yield return new WaitForSeconds(attackTime);
        }
        
        yield return new WaitForSeconds(changeFormDuration);
    }

    private IEnumerator SecondForm()
    {
        yield return new WaitForSeconds(attackTime);
        yield return new WaitForSeconds(changeFormDuration);
    }

    private IEnumerator ThirdForm()
    {
        yield return new WaitForSeconds(attackTime);
        yield return new WaitForSeconds(changeFormDuration);
    }

    private IEnumerator LastForm()
    {
        yield return new WaitForSeconds(attackTime);
    }

    public void ChangeBossForm()
    {
        // change form;
    }
}
