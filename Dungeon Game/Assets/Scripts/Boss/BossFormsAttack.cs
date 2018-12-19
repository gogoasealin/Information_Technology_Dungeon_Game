using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFormsAttack : MonoBehaviour
{
    private Vector3 startLocation;

    public float speed;
    public float attackTime;
    public float changeFormDuration;

    private void Start()
    {
        StartCoroutine(FirstForm());
    }



    private IEnumerator FirstForm()
    {
        Debug.Log("aici");
        yield return new WaitForSeconds(attackTime);
        yield return new WaitForSeconds(changeFormDuration);
        Debug.Log("aici2");
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
