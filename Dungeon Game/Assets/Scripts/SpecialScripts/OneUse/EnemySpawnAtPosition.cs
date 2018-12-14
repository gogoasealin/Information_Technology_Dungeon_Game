using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAtPosition : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform enemyPosition1;
    [SerializeField] private Transform enemyPosition2;
    [SerializeField] private float timeBetweenSpawn;
    private GameObject gameController;
    private GameController gameControllerScript;
    private Coroutine stop;


    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        stop = StartCoroutine(EnemySpawn());
    }

    private void Update()
    {
        if (gameControllerScript.death)
        {
            StopCoroutine(stop);

            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0; i< enemy.Length; i++)
            {
                Destroy(enemy[i]);
            }
            Destroy(GetComponent<EnemySpawnAtPosition>());
            
        }
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            int random, lastRandom;
            random = Random.Range(0, 2);
            if (random == 0)
            {
                Instantiate(enemy, enemyPosition1.position, Quaternion.identity);
                lastRandom = Random.Range(0, 2);
                if (lastRandom != random)
                {
                    Instantiate(enemy, enemyPosition2.position, Quaternion.identity);
                }
            }
            else
            {
                Instantiate(enemy, enemyPosition2.position, Quaternion.identity);
                lastRandom = Random.Range(0, 2);
                if (lastRandom != random)
                {
                    Instantiate(enemy, enemyPosition1.position, Quaternion.identity);
                }
            }

            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
