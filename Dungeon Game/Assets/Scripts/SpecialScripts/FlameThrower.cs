using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour {

    private GameObject gameController;
    private GameController gameControllerScript;
    [SerializeField] private float timeAfterAttack;
    [SerializeField] private GameObject shot;
    [SerializeField] private Transform shotPosition;



    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        StartCoroutine(Shot());
    }




    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameControllerScript.GameOver();
        }
        else if (other.gameObject.tag == "Shuriken")
        {
            Destroy(other.gameObject);
        }

    }

    IEnumerator Shot()
    {
        while (true)
        {
            if (!gameControllerScript.death)
            {
                Instantiate(shot, shotPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(timeAfterAttack);
            }
            else
            {
                StopCoroutine(Shot());
                break;
            }

        }
    }

}
