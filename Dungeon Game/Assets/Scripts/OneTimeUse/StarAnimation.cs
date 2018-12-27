using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{

    [SerializeField]private bool up;

    public GameObject boss;

    private void OnEnable()
    {
        up = true;
    }

    void Update()
    {
        if (up)
        {
            transform.localScale += new Vector3(0.02f, 0.02f, 0f);
            if (transform.localScale.x >= 1f)
            {
                up = false;
            }
        }
        else
        {
            transform.localScale -= new Vector3(0.02f, 0.02f, 0f);
            if (transform.localScale.x <= 0.01f)
            {
                up = true;
                boss.GetComponent<BossStageThree>().attack = true;
                gameObject.SetActive(false);
            }
        }

    }
}
