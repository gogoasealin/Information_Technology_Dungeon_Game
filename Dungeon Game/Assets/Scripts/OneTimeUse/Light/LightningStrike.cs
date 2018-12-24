using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    [SerializeField] GameObject lightning;
    private float timer;
    public float nextStrike;


    private void Start()
    {
        timer = 2f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= nextStrike)
        {
            lightning.SetActive(true);
            timer = 0;
        }
    }

}
