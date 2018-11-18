using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SearchForEnemy : MonoBehaviour {

    private GameObject[] enemys;
    private bool destroy;
    private GameObject gameManager;
    private GameManager gameManagerScript;


    private void Awake()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

    }


    void Update () {
        destroy = true;
        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i] != null)
            {
                destroy = false;
            }
        }
        if (destroy)
        {
            GetComponent<GoToNextLevel>().NexTLevel();
        }
    }


}
