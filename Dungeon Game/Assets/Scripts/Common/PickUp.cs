using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PickUp : MonoBehaviour {
   
    private GameObject player;
    [SerializeField]private bool carrying;
    [SerializeField]public bool canCarry;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().canJump = true;
        }
        else if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Shuriken")
        {
            Destroy(other.gameObject);
            return;
        }
        else if (other.gameObject.tag == "Environment") 
        {
            Drop();
        }
        else if (other.gameObject.tag == "Ground")
        {
            //if (!carrying && !canCarry)
            //{
            //    Debug.Log("da");
            //    gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            //}
            //else
            //{
                Drop();
            //}
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerController>().canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canCarry = true;
        }
        else if (other.tag == "Enemy" || other.tag == "Shuriken")
        {
            Destroy(other.gameObject);
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.transform.parent != player && other.gameObject.tag == "Player")
        {
            canCarry = false;
        }
    }

    private void Update()
    {
        if (canCarry)
        {
            if (!carrying)
            {
                CheckPickUp();
            }
            else
            {
                CheckDrop();
            }

        }
    }

    void CheckPickUp()
    {
        if (CrossPlatformInputManager.GetButtonDown("Use"))
        {
            PickUpObject();
        }
    }

    void PickUpObject()
    {
        gameObject.transform.parent = player.transform;
        gameObject.transform.localPosition = new Vector3(6f, 0.7f, 0);
        Destroy(GetComponent<Rigidbody2D>());
        carrying = true;
    }

    void CheckDrop()
    {
        if (CrossPlatformInputManager.GetButtonDown("Use"))
        {
            Drop();
        }
    }

    void Drop()
    {
        if (GetComponent<Rigidbody2D>() == null)
        {
            gameObject.transform.parent = null;
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

        carrying = false;
    }
}
