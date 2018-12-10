using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PortalScript : MonoBehaviour {

    [SerializeField] private Vector3 nextPosition;
    private GameObject player;
    [SerializeField]private bool enter;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        if(enter && CrossPlatformInputManager.GetButtonDown("Use"))
        {
            player.gameObject.transform.position = nextPosition;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
        
    //    if(other.tag == "Shuriken")
    //    {
    //        player.gameObject.transform.position = nextPosition;
    //        Destroy(other.gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            enter = true;      
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            enter = false;
        }
    }
}
