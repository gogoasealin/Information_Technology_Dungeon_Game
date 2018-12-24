using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class Boss : MonoBehaviour
{
    public int health;

    public Slider healthBar;
    public Animator anim;
    private GameController gameControllerScript;
    public ParticleSystem[] ps;

    public GameObject stageTwo;
    public GameObject stageThree;
    public GameObject stageFour;

    private void Start()
    {
        gameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
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
            GetNextPS(transform.position);
            Destroy(other.gameObject);
        }
        if(other.tag == "Player")
        {
            gameControllerScript.GameOver();
        }
    }

    private void GetNextPS(Vector3 hitPosition)
    {
        for(int i = 0; i < ps.Length; ++i)
        {
            if(!ps[i].isPaused)
            {
                ps[i].transform.position = hitPosition;
                ps[i].Play();
                return;
            }
        }
    }

    private void CheckBossHP()
    {
        health -= 1;
        healthBar.value = health;
        switch (health)
        {
            case 120:
                stageTwo.transform.position = transform.position;
                stageTwo.SetActive(true);
                gameObject.SetActive(false);
                break;
            case 80:
                stageThree.transform.position = transform.position;
                stageThree.SetActive(true);
                gameObject.SetActive(false);
                break;
            case 40:
                stageFour.transform.position = transform.position;
                stageFour.SetActive(true);
                gameObject.SetActive(false);
                break;
            case 0:
                Debug.Log("death");
                healthBar.gameObject.SetActive(false);
                gameObject.SetActive(false);
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
