using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    ParticleSystem ps;
    GameObject boss;
    bool stop;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            boss.SetActive(false);
        }
     
    }

    void Update()
    {
        if (!stop)
        {

            if (ps.shape.radius >= 4 && boss != null)
            {
                boss.SetActive(true);
            }

            if (ps.shape.radius <= 6)
            {
                var shape = ps.shape;
                shape.radius += Time.deltaTime * 4;
            }
            else
            {
                stop = true;
            }
        }
        else{
            var shape = ps.shape;
            shape.radius -= Time.deltaTime * 5;

            if(ps.shape.radius <= 0.1)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
