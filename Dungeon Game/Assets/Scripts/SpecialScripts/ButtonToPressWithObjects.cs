using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToPressWithObjects : MonoBehaviour {

    [SerializeField]GameObject objectToMove;
    private bool goUp;
    [SerializeField] private Vector3 upPosition;
    private PlayerController playerController;
    private Vector3 downPosition;
    private float speed = 1;
    public LayerMask layerMask;

    private void Start()
    {
        downPosition = objectToMove.transform.position;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerController.canJump = true;
        }
    }

    private void CheckButtonPressed()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.1f, layerMask);
        //for(int i = 0; i < hitColliders.Length; ++i)
        //{
        //    Debug.Log(hitColliders[i].name);
        //}
        if (hitColliders.Length >= 1)
        {
            goUp = true;
            return;
        }
        goUp = false;
    }

    private void Update()
    {
        CheckButtonPressed();
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
