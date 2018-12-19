using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float leftConstraint;
    float rightConstraint;
    public float overFlow;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0f, 0f, -10)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, -10)).x;
    }

    private void FixedUpdate()
    {
        if(transform.position.x <= leftConstraint - overFlow)
        {
            transform.position = new Vector3(rightConstraint + 0.1f, transform.position.y, 0);
        }
        if (transform.position.x >= rightConstraint + overFlow)
        {
            transform.position = new Vector3(leftConstraint - 0.1f, transform.position.y, 0);
        }
    }
}
