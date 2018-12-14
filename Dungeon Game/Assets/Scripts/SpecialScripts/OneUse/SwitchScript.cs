using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class SwitchScript : MonoBehaviour {

    [SerializeField] private Sprite sprite1;
    [SerializeField] private Sprite sprite2;

    private int hit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shuriken")
        {
            hit++;//loveste de 2 ori ...
            if (hit % 2 == 0)
            {
                if (GetComponent<SpriteRenderer>().sprite == sprite1)
                {
                    GetComponent<SpriteRenderer>().sprite = sprite2;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = sprite1;
                }
            }
            Destroy(other.gameObject);

        }
    }
}
