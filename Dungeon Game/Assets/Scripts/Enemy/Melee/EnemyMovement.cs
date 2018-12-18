using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    private Animator anim;
    public AnimationClip animDie;
    [SerializeField] private bool playerFound;
    private GameObject player;
    private float moveSpeed;
    private Vector3 lastKnowPosition;
    private Vector3 startPosition;
    [SerializeField] private bool hitSomething;
    [SerializeField] private int numberOfHitToDie;
    private int getHit;
    [SerializeField] private int anotherEnemyHit;
    private bool dieStart;
    [SerializeField] private bool once;
    [SerializeField] private bool searchOnce;
    [SerializeField] private bool reachPosition;


    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        moveSpeed = 1f;
        startPosition = gameObject.transform.position;
        lastKnowPosition = startPosition;
    }

    private void Update()
    {
        if (playerFound)
        {
            FollowPlayer();
        }
        else if(!playerFound && once)
        {
            if (!reachPosition && !searchOnce)
            {
                GoToLastPosition();
            }
            else if(reachPosition && !searchOnce)
            {
                GoBack();
            }
            
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (!once)
            {
                lastKnowPosition = new Vector3(other.transform.position.x, gameObject.transform.position.y, 0);
                once = true;
                searchOnce = false;
            }
            playerFound = true;


        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            lastKnowPosition = new Vector3(other.transform.position.x, gameObject.transform.position.y, 0);
            playerFound = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerFound = false;
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
                    StartCoroutine(DieEnemyFollower());
                }
            }
        }
        else if (other.gameObject.tag == "Ground")
        {
            return;
        }
        else if(other.gameObject.tag == "Enemy")
        {
            anotherEnemyHit++;
            if (anotherEnemyHit >= 3)
            {
                hitSomething = true;
                reachPosition = true;
                anotherEnemyHit = 0;
            }
        }
        else if(other.gameObject.tag != "Bomb" )
        {
            hitSomething = true;
        }


    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            anotherEnemyHit++;
            if (anotherEnemyHit >= 3)
            {
                hitSomething = true;
                anotherEnemyHit = 0;
            }
        }
        
    }

    private void FollowPlayer()
    {
        if (!hitSomething)
        {
            if (CalculateDistance())
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector3(player.transform.position.x, gameObject.transform.position.y, 0), Time.deltaTime * moveSpeed);
                lastKnowPosition = new Vector3(player.transform.position.x, gameObject.transform.position.y, 0);
            }
            else
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, lastKnowPosition, Time.deltaTime * moveSpeed);
            }
        }else
        {
            GoBack();
        }
    }

    private void GoToLastPosition()
    {
        if (!hitSomething)
        {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector3(lastKnowPosition.x, gameObject.transform.position.y, 0), Time.deltaTime * moveSpeed);            
                if (gameObject.transform.position.x == lastKnowPosition.x)
                {
                    reachPosition = true;
                }         
        }
        else
        {
            GoBack();
        }
    }

    private bool CalculateDistance()
    {
        if (player != null)
        {
            Vector3 playerHigh = player.transform.position;
            Vector3 enemyHigh = gameObject.transform.position;

            if (Mathf.Abs(Mathf.Abs(playerHigh.y) - Mathf.Abs(enemyHigh.y)) <= 0.1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            lastKnowPosition = startPosition;
            return false;
        }
    }

    private void GoBack()
    {
        if (Mathf.Abs(gameObject.transform.position.y - startPosition.y) < 50f)
        {
            
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, startPosition, Time.deltaTime * moveSpeed);
            if (gameObject.transform.position.x == startPosition.x)
            {
                hitSomething = false;
                searchOnce = false;
                once = false;
                reachPosition = false;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DieEnemyFollower()
    {
        dieStart = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        anim.SetBool("die", true);
        yield return new WaitForSeconds(animDie.length);
        Destroy(gameObject);
    }
}
