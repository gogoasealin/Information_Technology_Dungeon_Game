using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BombInstantiate : MonoBehaviour {

    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject bombSpawn;
    private float nextBombTimer;

    private void Start()
    {
        nextBombTimer = 3f;
    }

    void Update()
    {
        nextBombTimer += Time.deltaTime;
        if (CrossPlatformInputManager.GetButtonDown("Use") && (nextBombTimer >= 2f) || Input.GetKeyDown(KeyCode.E) && (nextBombTimer >= 2f))
        {
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
            nextBombTimer = 0f;
        }
    }
}
