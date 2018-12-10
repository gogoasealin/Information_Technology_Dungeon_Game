using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnTrigger : MonoBehaviour
{

    [SerializeField] private GameObject enemyToInstantiate;
    [SerializeField] private Vector3 instantiatePosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(enemyToInstantiate, instantiatePosition, Quaternion.identity);
            Destroy(gameObject.GetComponent<InstantiateOnTrigger>());
        }
    }
}
