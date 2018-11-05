using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMovement : MonoBehaviour {

    public float y;
    private bool playerTrigger;
    private Vector3 destination;
    private Vector3 origin;
    private GameObject spikes;
    private float timer;
    private bool spikeMovement;

    private void Start()
    {
        spikeMovement = false;
        spikes = gameObject.transform.GetChild(0).gameObject;
        origin = spikes.transform.position;
        destination = spikes.transform.position + new Vector3 (0, y, 0);


    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerTrigger = true;
            spikes.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerTrigger = false;
        }
    }

    void Update () {
	    if(playerTrigger)
        {
            spikes.GetComponent<SpriteRenderer>().enabled = true;
            spikes.gameObject.transform.position = Vector2.MoveTowards(new Vector2(spikes.transform.position.x, spikes.transform.position.y), destination, 1 * Time.deltaTime);
            timer = 0;
        }else
        {
            timer += Time.deltaTime;
            if(timer > 3f)
            {
                timer = 0;
                spikeMovement = true;
            }

            if (spikeMovement)
            {
                spikes.gameObject.transform.position = Vector2.MoveTowards(new Vector2(spikes.transform.position.x, spikes.transform.position.y), origin, 1 * Time.deltaTime);
            }

            if (spikes.gameObject.transform.position.x == origin.x && spikes.gameObject.transform.position.y == origin.y)
            {
                spikes.GetComponent<SpriteRenderer>().enabled = false;
                spikeMovement = false;
            }
        }
	}
}
