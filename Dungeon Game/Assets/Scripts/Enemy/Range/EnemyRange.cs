using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour {

    private GameObject gameController;
    private GameController gameControllerScript;
    private Animator anim;
    public AnimationClip animDie;
    private int getHit;
    [SerializeField] private float timeAfterAttack;   
    [SerializeField] private int numberOfHitToDie;
    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shotPosition;
    private bool dieStart;
    Coroutine ShotBullet;




    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ShotBullet = StartCoroutine(Shot()); ;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StopCoroutine(ShotBullet);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Shuriken")
        {
            getHit++;
            Destroy(other.gameObject);
            if (getHit == numberOfHitToDie)
            {
                if (!dieStart)
                {
                    StartCoroutine(DieEnemyRange());
                }
            }
        }

    }

    private IEnumerator DieEnemyRange()
    {
        dieStart = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("die", true);
        yield return new WaitForSeconds(animDie.length);
        Destroy(gameObject);
    }

    IEnumerator Shot()
    {
        while (true)
        {
            if (!gameControllerScript.death && !dieStart)
            {
                Instantiate(shot, shotPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(timeAfterAttack);
            }else
            {
                StopCoroutine(ShotBullet);
                break;
            }

        }
    }


}
