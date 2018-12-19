using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Boss : MonoBehaviour
{
    public int health;

    public Slider healthBar;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();   
    }

    private void OnEnable()
    {
        healthBar.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shuriken")
        {
            CheckBossHP();
            Destroy(other.gameObject);
        }
    }


    private void CheckBossHP()
    {
        health -= 1;
        healthBar.value = health;
        switch (health)
        {
            case 75:
                anim.SetTrigger("stageTwo");
                break;
            case 50:
                anim.SetTrigger("stageThree");
                break;
            case 25:
                anim.SetTrigger("stageFour");
                break;
            case 0:
                anim.SetTrigger("death");
                break;
            default:
                break;
        }
    }

    public void TheEnd()
    {
        healthBar.gameObject.SetActive(false);
        //inst destruction
        gameObject.SetActive(false);
    }
}
