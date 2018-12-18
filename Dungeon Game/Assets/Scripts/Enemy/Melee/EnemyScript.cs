using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {


    private Animator anim;
    public AnimationClip animDie;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shuriken")
        {
            Destroy(other.gameObject);
            StartCoroutine(Die());
        }
    }


    private IEnumerator Die()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("die", true);
        yield return new WaitForSeconds(animDie.length);
        Destroy(gameObject);
    }
}
