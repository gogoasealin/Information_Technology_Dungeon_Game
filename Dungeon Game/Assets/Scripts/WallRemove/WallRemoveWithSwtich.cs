using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRemoveWithSwtich : MonoBehaviour {

    [SerializeField]private GameObject switch1;
    [SerializeField] private Sprite switch1Sprite;
    [SerializeField] private GameObject switch2;
    [SerializeField] private Sprite switch2Sprite;
    [SerializeField] private GameObject switch3;
    [SerializeField] private Sprite switch3Sprite;

    private void Awake()
    {
        if(switch1 == null || switch2 == null || switch3 == null )
        {
            Destroy(gameObject.GetComponent<WallRemoveWithSwtich>());
        }
    }
    void Update () {

        if (switch1.GetComponent<SpriteRenderer>().sprite == switch1Sprite
            && switch2.GetComponent<SpriteRenderer>().sprite == switch2Sprite
            && switch3.GetComponent<SpriteRenderer>().sprite == switch3Sprite
            )
        {
            Destroy(gameObject);
        }


    }
}
