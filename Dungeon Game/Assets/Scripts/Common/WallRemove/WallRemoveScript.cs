using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRemoveScript : MonoBehaviour {

    public GameObject[] targets;
    private bool destroy;
	
	void Update () {
        destroy = true;
        for(int i = 0; i < targets.Length; i++)
        {
            if(targets[i] != null)
            {
                destroy = false;
            }
        }
	    if(destroy)
        {
            Destroy(gameObject);
        }	
	}
}
