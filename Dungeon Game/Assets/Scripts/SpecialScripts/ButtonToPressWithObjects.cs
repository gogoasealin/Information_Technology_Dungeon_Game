using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToPressWithObjects : MonoBehaviour {

    [SerializeField]GameObject objectToMove;
    private bool goUp;
    [SerializeField] private Vector3 upPosition;
    private GameObject Player;
    private PlayerController playerController;
    private Vector3 downPosition;
    private float speed = 1;

    private void Start()
    {
        downPosition = objectToMove.transform.position;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Ground")
        {
            goUp = true;
        }
        if(other.gameObject.tag == "Player")
        {
            playerController.canJump = true;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag != "Ground")
        {
            goUp = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag != "Ground")
        {
            goUp = false;
        }

        if (other.gameObject.tag == "Player")
        {
            playerController.canJump = false;
        }
    }

    private void Update()
    {
        if (goUp)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, upPosition, Time.deltaTime * speed);
        }
        else
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, downPosition, Time.deltaTime * speed);
        }
    }
}
