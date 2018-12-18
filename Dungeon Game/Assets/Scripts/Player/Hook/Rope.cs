using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject player;
    public Vector3 grabPos;

    void Update()
    {
        float scaleX = Vector3.Distance(player.transform.position, grabPos);
        GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(scaleX, 1f);
    }
}
