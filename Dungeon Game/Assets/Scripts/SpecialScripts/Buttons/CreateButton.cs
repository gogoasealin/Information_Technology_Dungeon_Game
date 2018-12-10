using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateButton : MonoBehaviour {

    [SerializeField] private GameObject Button;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameObject button = Instantiate(Button, new Vector3(0, 0, 0), Quaternion.identity)as GameObject;
            button.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            button.tag = "ForDestroy";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(GameObject.FindGameObjectWithTag("ForDestroy"));
        }
    }
}
