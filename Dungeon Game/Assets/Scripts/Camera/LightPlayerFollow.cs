using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlayerFollow : MonoBehaviour {

    private Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, -0.2f);
        }
    }
}
